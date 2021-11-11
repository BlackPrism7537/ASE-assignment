using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_assignment
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        public static void RunCommandLine(string command)
        {
            Console.WriteLine("command: " + command);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunCommandLine("Enter Key");
            }
            
        }

        private void RunCommandButton_Click(object sender, EventArgs e)
        {
            RunCommandLine("Button Click");
        }
    }
}
