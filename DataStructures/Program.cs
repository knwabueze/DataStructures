using DataStructures.Collections;
using DataStructures.Forms;
using DataStructures.Sorting;
using DataStructures.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructures
{
    public class Program
    {
        private static Mountain mountainForm;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mountainForm = new Mountain();
            Application.Run(mountainForm);
        }
    }
}
