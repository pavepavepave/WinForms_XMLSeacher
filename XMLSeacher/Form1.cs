using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (SearchPath.Text == string.Empty || SelectedKey.Text == string.Empty)
            {
                    MessageBox.Show("Не указан путь или ключ поиска!", "Error", MessageBoxButtons.OK);
            }
            if (SelectedKey.Text != string.Empty && SearchPath.Text != string.Empty)
            {
                Search searcher = new Search(SearchPath.Text, SelectedKey.Text);
                richTextBox1.Clear();
                searcher.StartSearch();
            }
        }
        public void AddToRichBox(string value)
        {
            richTextBox1.Text += value + "\n";
        }
    }
}
