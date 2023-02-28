using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLSeacher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static Form1 forms = new Form1();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(forms);
        }
    }
}
