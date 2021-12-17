open System
open System.Threading

let rec work (name: string) (counter: int) : unit =
    Thread.Sleep(TimeSpan.FromSeconds(1.0))
    let printedName = BinocularsLib.Say.hello name
    printfn $"{counter}.\t{printedName}"
    work name (counter + 1)

work "Piotr" 0