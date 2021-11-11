﻿using System;
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

        /// <summary>
        /// converts raw string into string array 
        /// splits at each new line and new line char trimmed
        /// </summary>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static string[] RawStringToProgram(string raw)
        {
            string[] rawArray = raw.Split('\n');
            string[] Program = rawArray.Select(x => x.TrimEnd('\r', '\n')).ToArray();

            return Program;
        }

        /// <summary>
        /// takes string command and runs it
        /// </summary>
        /// <param name="command"></param>
        public static void RunCommandLine(string command)
        {
            Console.WriteLine("command: " + command);
        }


        /// <summary>
        /// takes array of strings and individually runs them through the RunCommand() method
        /// </summary>
        /// <param name="program"></param>
        public static void RunProgram(string[] program)
        {
            Console.WriteLine("Running Program...");
            foreach (string line in program)
            {
                RunCommandLine(line);
            }
            Console.WriteLine("Program Complete!");
        }

        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RunCommandLine(this.CommandLine.Text);
                this.CommandLine.Text = "";
            }
        }

        private void RunCommandButton_Click(object sender, EventArgs e)
        {
            RunCommandLine("Button Click");
            this.CommandLine.Text = "";
        }

        private void RunProgramButton_Click(object sender, EventArgs e)
        {
            string[] program = RawStringToProgram(this.ProgramInput.Text);
            RunProgram(program);
        }
    }
}