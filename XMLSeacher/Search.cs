using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace XMLSeacher
{
    public class Search
    {
        private string path;
        private string _searchKey;
        public string Path { get => path; set => path = value; }
        public string SearchKey { get => _searchKey; set => _searchKey = value; }
        public Search(string path, string searchKey)
        {
            this.Path = path;
            this.SearchKey = searchKey;

        }

        public void StartSearch()
        {
            Logs.ClearText();
            int count = 0;
            var fw = Directory.GetFiles(Path, "*.xml");
            foreach (var file in fw)
            {
                var fileInfo = new FileInfo(file);
                var openFiles = File.ReadAllText(file);
                if (openFiles.Contains(SearchKey))
                {
                    count++; 
                    Logs.WriteText(fileInfo.Name);
                    Program.forms.AddToRichBox(fileInfo.Name);
                }
            }

            if (count == 0)
            {
                Program.forms.AddToRichBox($"Совпадений не найдено");
            }
            else
            {
                Program.forms.AddToRichBox($"Найдено {count} совпадений(-ая).");
            }
        }
    }
}