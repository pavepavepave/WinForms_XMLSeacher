using System.IO;
using System.Text;

public class Logs
{
    private string _fileWrites = null;
    private readonly string _logFilesName;

    public Logs(string logFilesName)
    {
        _logFilesName = logFilesName;
    }

    public void WriteText(string message)
    {
        _fileWrites = $"{message}\n";
        using (var sw = new StreamWriter(_logFilesName, false, Encoding.UTF8))
        {
            sw.WriteLine(_fileWrites);
            sw.Flush();
            sw.Close();
        }
    }
    public void ClearText()
    {
        using (var sw = new StreamWriter(_logFilesName, false, Encoding.UTF8))
        {
            sw.WriteLine("\0");
            sw.Flush();
            sw.Close();

        }
    }
}

