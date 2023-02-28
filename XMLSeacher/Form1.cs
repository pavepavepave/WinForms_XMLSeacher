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


        public void ChooseFolder_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Заполните путь или ключ поиска!", "Error", MessageBoxButtons.OK);
            }
            if (SelectedKey.Text != string.Empty && SearchPath.Text != string.Empty)
            {
                Search searcher = new Search(SearchPath.Text, SelectedKey.Text);
                searcher.StartSearch();
            }
        }

    }
}
