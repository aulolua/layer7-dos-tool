Imports System.Net.Http
Imports System.Diagnostics
Imports System.Threading.Tasks

Module Program

    Sub Main(args As String())
        If args.Length < 2 Then
            Console.WriteLine("Usage: dotnet run <url> <duration>")
            Return
        End If

        Dim url As String = args(0)
        Dim duration As Integer = Integer.Parse(args(1))

        MeasureSpeed(url, duration).Wait()
    End Sub

    Private Async Function MeasureSpeed(url As String, duration As Integer) As Task
        Using client As New HttpClient()
            Dim totalUpload As ULong = 0UL
            Dim totalDownload As ULong = 0UL
            Dim totalRequests As ULong = 0UL
            Dim startTime As DateTime = DateTime.Now
            Dim lastUpdateTime As DateTime = DateTime.Now

            Console.WriteLine($"Testing speeds for {duration} seconds...")

            While (DateTime.Now - startTime).TotalSeconds < duration
                Dim uploadResponseTask = client.SendAsync(New HttpRequestMessage(HttpMethod.Head, url))
                totalUpload += 1UL

                Dim downloadResponseTask = client.GetAsync(url)
                totalRequests += 2UL


                Dim elapsedSeconds As Double = (DateTime.Now - startTime).TotalSeconds
                Dim uploadSpeed = totalUpload/1024 / elapsedSeconds
                Dim downloadSpeed = totalDownload/1024 / elapsedSeconds
                Dim requestsPerSecond = totalRequests / elapsedSeconds


                Dim timeSinceLastUpdate = DateTime.Now - lastUpdateTime
                If timeSinceLastUpdate.TotalSeconds >= 1 Then
                    Console.Title = $"Upload: {uploadSpeed:F2} KBps | Download: {downloadSpeed:F2} KBps | Req: {requestsPerSecond:F2} rps"
                    lastUpdateTime = DateTime.Now
                End If


                Dim minInterval As TimeSpan = TimeSpan.FromSeconds(1)
                Dim elapsedSinceLastRequest = DateTime.Now - startTime
                If elapsedSinceLastRequest < minInterval Then
                    Await Task.Delay(minInterval - elapsedSinceLastRequest)
                End If
            End While

            Console.WriteLine("Speed test completed.")
        End Using
    End Function

End Module
