using System;
using System.IO;
using System.Text;

public static class Logs
{
    private static string _fileWrites = "";
    private static readonly string _logFilesName = "logs.txt";
    private static readonly string _lastPathFile = "path.txt";
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
    public static void RememberLastPath(string path)
    {
        if (File.Exists(_lastPathFile))
        {
            File.Delete(_lastPathFile);
        }
        File.AppendAllText(_lastPathFile, path);
    }
    public static string GetLastPath()
    {
        if (!File.Exists(_lastPathFile) || File.ReadAllLines(_lastPathFile).Length == 0)
        {
            File.AppendAllText(_lastPathFile, "0");
        }
        return File.ReadAllLines(_lastPathFile)[0];

    }
}

