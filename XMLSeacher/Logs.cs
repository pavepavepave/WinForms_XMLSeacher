using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Logs
{
    private static string _fileWrites = "";
    private static readonly string _logFilesName = $"logs.txt";
    private static string _lastPath { get; set; }
    public static void WriteText(string message)
    {
        _fileWrites += message + "\n";
        using (var sw = new StreamWriter(_logFilesName, false, Encoding.UTF8))
        {
            sw.WriteLine(_fileWrites);
        }
    }
    public static void ClearText()
    {
        using (var sw = new StreamWriter(_logFilesName, false, Encoding.UTF8))
        {
            sw.WriteLine("");
        }
    }
    public static void RememberLastPath()
    {

    }
    public static void GetLastPath()
    {

    }
}

