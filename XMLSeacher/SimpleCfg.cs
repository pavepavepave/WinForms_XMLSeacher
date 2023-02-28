using System.IO;
using System.Text;

namespace XMLSeacher
{
    public class PathConfig
    {
        private readonly string _configsName;
        public string Path { get; set; } 

        public PathConfig(string cfgName)
        {
            _configsName = cfgName;

            if (!File.Exists(_configsName))
                File.Create(_configsName);
        }

        public void Save()
        {
            using (var sw = new StreamWriter(_configsName, false, Encoding.UTF8))
            {
                sw.WriteLine(Path);
                sw.Flush();
                sw.Close();
            }
        }

        public void Load() 
        {
            using (var sr = new StreamReader(_configsName, Encoding.UTF8))
            {
               Path = sr.ReadLine();
               sr.Close();
            }
        }
    }
}
