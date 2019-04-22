# TopshelfDotNetCoreExample
An example of how to use Topshelf with .NET core

To run as a console app:
```
dotnet run 
```

To install as a Windows service, first publish targetting Windows:
```
dotnet publish TopshelfDotNetCoreExample.csproj -r win10-x64
```

and then use the Topshelf install command on the .exe file:
```
cd TopshelfDotNetCoreExample\bin\Debug\netcoreapp2.2\win10-x64\publish
TopshelDotNetCoreExample.exe install
```
