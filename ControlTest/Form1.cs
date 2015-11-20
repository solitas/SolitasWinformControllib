using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllib.Controls;

namespace ControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserTabRenderer renderer = new FlatTabRenderer();
            userTabControl1.TabRenderer = renderer;

            int value = addint(10, 20);
            Console.WriteLine("10+20 = {0}", value);
        }

        [DllImport("Win32UnmanagedLib.dll")]
        public static extern int addint(int n1, int n2);
        [DllImport("Win32UnmanagedLib.dll")]
        public static extern int addchar(string s1, string s2, StringBuilder sum);
    }
}
