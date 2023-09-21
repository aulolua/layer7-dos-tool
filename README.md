# HTTP Speed Measurement Tool

This simple tool measures upload speed, download speed, and requests per second for a specified URL over a given duration.

## Usage

1. Ensure you have the .NET Core SDK installed.
2. Open a command prompt or terminal.
3. Navigate to the directory containing the compiled program or the source code.
4. Run the program using the following command:
### OR
1. Download speed.exe and dll files(or the [zip](https://github.com/aulolua/layer7-dos-method/releases/download/alpha/speed.zip) ) etc from releases of this github repo
2. Open Command Prompt or Terminal
3. navigate to downloaded file
4. Run the Program using the code in next block.

```bash
dotnet run <url> <duration>
speed <url> <duration>
```

Replace `<url>` with the URL you want to test and `<duration>` with the duration of the test in seconds.

## Example

To test "https://example.com" for 10 seconds:

```bash
dotnet run https://example.com 10
speed https://example.com 10
```

## Build

The program can be built using the .NET Core SDK. Use the following command to build the program:

```bash
dotnet build
```

## License

This tool is provided under the [MIT License](LICENSE).
