# Setup .NET 6

* install .NET 6
  - https://dotnet.microsoft.com/en-us/download/dotnet/6.0
* install Moicrosoft C# Extension (`C# for Visual Studio Code`)
  - VSXode > Extensions > type in `C#` to search

```bash
dotnet --version
# 6.0.101
```

* try console app https://aka.ms/dotnet-hello-world

```bash
dotnet new console -o HelloWorld
# (optional) DOTNET_CLI_TELEMETRY_OPTOUT=true

cd HelloWorld/
dotnet run
# Hello, World!
```
