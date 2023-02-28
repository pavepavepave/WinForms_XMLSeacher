using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Logs
{
    private static string fileWrites = "";

    public static void WriteText(string message)
    {
        fileWrites += message + "\n";
        using (var sw = new StreamWriter($"logs.txt", false, Encoding.UTF8))
        {
            sw.WriteLine(fileWrites);
        }
    }
}

