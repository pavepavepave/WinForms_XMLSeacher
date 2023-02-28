using System;
using System.IO;
using System.Windows.Forms;

namespace XMLSeacher
{
    public class Search
    {
        private string path;
        private string _search_key;
        public string Path { get => path; set => path = value; }
        public string SearchKey { get => _search_key; set => _search_key = value; }
        public Search(string path, string searchKey)
        {
            Path = path;
            SearchKey = searchKey;
        }
        public void StartSearch(Logs logger, ref RichTextBox richTextBox)
        {
            logger.ClearText();

            int count = 0;
            var fw = Directory.GetFiles(Path, "*.xml");
            
            foreach (var file in fw)
            {
                var fileName = new FileInfo(file);
                var openFiles = File.ReadAllText(file);
                if (openFiles.Contains(SearchKey))
                {
                    count++; 
                    logger.WriteText(fileName.Name);
                    richTextBox.Text += $"{fileName.Name} \n";
                }
            }

            richTextBox.Text += (count == 0 ? $"Совпадений не найдено" : $"Найдено {count} совпадений(-ая).");
        }
    }
}