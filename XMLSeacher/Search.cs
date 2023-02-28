using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLSeacher;

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
            int count = 0;
            Console.WriteLine("\n" + "Ваш результат: " + "\n");
            var fw = Directory.GetFiles(Path, "*.xml");
            foreach (var file in fw)
            {
                var fileInfo = new FileInfo(file);
                var openFiles = File.ReadAllText(file);
                if (openFiles.Contains(_searchKey))
                {

                    Logs.WriteText(fileInfo.Name);
                    count++;
                }
            }
        }
    }
}