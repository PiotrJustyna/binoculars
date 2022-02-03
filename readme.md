# readme

This is a quick project to test how `dotnet watch` works in order to determine whether it would be a good candidate for code hot swapping. Sample usage: https://docs.microsoft.com/en-us/aspnet/core/tutorials/dotnet-watch?view=aspnetcore-6.0

Tu run:

```
dotnet watch run --project BinocularsHost/BinocularsHost.fsproj
```

## conclusion

The tool is not for hot-swapping dependencies written in F#. It does however works correctly for C# code. Further explanation:

1. C# host + F# library: cold swap
2. C# host + C# library: **hot swap**
3. F# host + F# library: cold swap

## illustrations

C# host + F# library or F# host + F# library:

```
watch : Started
0.      PID: 3798 - Hello, Piotr!
1.      PID: 3798 - Hello, Piotr!
watch : File changed: /Users/justpi01/Documents/code/binoculars/BinocularsLib/Library.fs.
watch : Do you want to restart your app - Yes (y) / No (n) / Always (a) / Never (v)?
2.      PID: 3798 - Hello, Piotr!
3.      PID: 3798 - Hello, Piotr!
4.      PID: 3798 - Hello, Piotr!
watch : Hot reload suspended. To continue hot reload, press "Ctrl + R".
5.      PID: 3798 - Hello, Piotr!
watch : Building...
  BinocularsLib -> /Users/justpi01/Documents/code/binoculars/BinocularsLib/bin/Debug/net6.0/BinocularsLib.dll
  BinocularsHostCS1 -> /Users/justpi01/Documents/code/binoculars/BinocularsHostCS1/bin/Debug/net6.0/BinocularsHostCS1.dll
watch : Started
0.      PID: 3817 - Hello, Piotr!!
1.      PID: 3817 - Hello, Piotr!!
2.      PID: 3817 - Hello, Piotr!!
```

C# host + C# library:

```
watch : Started
0.      PID: 3503 - Hello, Piotr!!
1.      PID: 3503 - Hello, Piotr!!
watch : File changed: /Users/justpi01/Documents/code/binoculars/BinocularsLibCS/Library.cs.
2.      PID: 3503 - Hello, Piotr!!
3.      PID: 3503 - Hello, Piotr!!
4.      PID: 3503 - Hello, Piotr!!
watch : Hot reload of changes succeeded.
5.      PID: 3503 - Hello, Piotr!
6.      PID: 3503 - Hello, Piotr!
7.      PID: 3503 - Hello, Piotr!
8.      PID: 3503 - Hello, Piotr!
```

## post mortem

There is one idea I still want to try. What I've been trying so far was hot reloads triggered by changes to the source code of the dependencies. I want to explore running a published version of the host (C#) with a watch and dropping in a compiled F# dll. Let's see if that works and that is what I'm currently exploring.