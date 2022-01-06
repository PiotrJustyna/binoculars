using System;

namespace BinocularsLib
{
    public class Library
    {
        public static string hello(string name)
        {
            return $"PID: {Environment.ProcessId} - Hello, {name}!!";
        }
    }
}