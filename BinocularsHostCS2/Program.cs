// See https://aka.ms/new-console-template for more information

using System;
using System.Threading;

int counter = 0;

while (true)
{
    Thread.Sleep(TimeSpan.FromSeconds(1.0));

    var printedName = BinocularsLib.Library.hello("Piotr");

    Console.WriteLine($"{counter++}.\t{printedName}");
}