namespace BinocularsLib

open System

module Say =
    let hello (name: string) : string = $"PID: {Environment.ProcessId} - Hello, {name}!"