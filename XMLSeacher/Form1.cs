using System;
using System.IO;
using System.Windows.Forms;

namespace XMLSeacher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();

        }

        private void ChooseFolder_Click(object sender, EventArgs e)
        {
            using (var folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                    SearchPath.Text = folder.SelectedPath;
            }
        }

        bool CheckString(string str)
        {
            try
            {
                if (str == string.Empty)
                    MessageBox.Show("Значение не может быть пустым." + "", "Error", MessageBoxButtons.OK);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Значение не может быть пустым.", "Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (!CheckString(SearchPath.Text) || !CheckString(SelectedKey.Text))
                return;

            Logs p = new Logs("logs.txt");

            try
            {
                Search searcher = new Search(SearchPath.Text, SelectedKey.Text);
                richTextBox1.Clear();
                searcher.StartSearch(p, ref richTextBox1);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Указанного пути не существует", "Error", MessageBoxButtons.OK);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("mycfg.cfg"))
                File.AppendAllText("mycfg.cfg", "Укажите папку поиска");
            PathConfig configRead = new PathConfig("mycfg.cfg");
            configRead.Load();
            SearchPath.Text = configRead.Path;
        }

        private void SearchPath_TextChanged(object sender, EventArgs e)
        {
            PathConfig configWrite = new PathConfig("mycfg.cfg");

            if (!CheckString(SearchPath.Text) && SearchPath.Text.Length < 3 || SearchPath.Text == configWrite.Path)
                return;

            configWrite.Path = SearchPath.Text;
            configWrite.Save();
        }
    }
}
