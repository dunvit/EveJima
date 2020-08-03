# EveJima
Tool for game Eve Online

Eve forum:

http://forum.eve-ru.com/index.php?showtopic=116834

----

__Logs__:

Open file `EveJima.exe.config` and replace from `<level value="DEBUG"/>` to `<level value="ERROR"/>`

Open folder `Logs` and send filr `Log.txt` to email sushilov.vitaly@gmail.com 

----

__Requirement__:

`NET Framework 4.5.2` - https://dotnet.microsoft.com/download/dotnet-framework/thank-you/net452-web-installer

__Crash fixes__:

- Check framework `NET Framework 4.5.2` (See previous paragraph)

- Remove  `IE11` from your computer

- Open file `EveJima.exe.config` and replace from `<add key="BrowserType" value="chromiumWebBrowser" />` to `<add key="BrowserType" value="netWebBrowser" />`
