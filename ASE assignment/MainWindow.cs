﻿using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_assignment
{
	public partial class MainWindow : Form
	{

		CommandParser parser;
		Canvas canvas;
		Bitmap bitmap = new Bitmap(300, 300);
		string[] output;

		public MainWindow()
		{
			InitializeComponent();
			this.canvas = new Canvas(Graphics.FromImage(this.bitmap));
			this.parser = new CommandParser(canvas);
		}

		/// <summary>
		/// takes string command and runs it
		/// </summary>
		/// <param name="command"></param>
		public void RunCommandLine(string command)
		{
			try
			{
				this.parser.ParseCommand(command);
				this.pictureBox1.Refresh();
			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!");
			}
				
		}

        public CommandParser GetParser()
        {
            return parser;
        }

        /// <summary>
        /// takes string, converts into string array and individually runs them through the RunCommand() method
        /// </summary>
        /// <param name="program"></param>
        public void RunProgram(string rawInput, CommandParser parser)
		{
            Console.WriteLine("Running Program...");
            string[] program = CommandParser.RawStringToProgram(rawInput);
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
				if (this.CommandLine.Text == "run") RunProgram(this.ProgramInput.Text, GetParser());
				else RunCommandLine(this.CommandLine.Text);
				this.CommandLine.Text = "";
			}
		}

		private void RunCommandButton_Click(object sender, EventArgs e)
		{
			if(this.CommandLine.Text == "run") RunProgram(this.ProgramInput.Text, GetParser());
			else RunCommandLine(this.CommandLine.Text);
			this.CommandLine.Text = "";
		}

		private void RunProgramButton_Click(object sender, EventArgs e)
		{
			RunProgram(this.ProgramInput.Text, GetParser());
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImageUnscaled(this.bitmap, 0, 0);
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fileContent = "";

			OpenFileDialog open = new OpenFileDialog();
			open.InitialDirectory = "c:\\";
			open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			open.FilterIndex = 2;
			open.RestoreDirectory = true;

			if (open.ShowDialog() == DialogResult.OK)
			{
				//Get the path of specified file
				string filePath = open.FileName;

				fileContent = System.IO.File.ReadAllText(filePath);
			}

			open.Dispose();

			this.ProgramInput.Text = fileContent;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string fileContent = this.ProgramInput.Text;

			SaveFileDialog save = new SaveFileDialog();
			save.InitialDirectory = "c:\\";
			save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			save.FilterIndex = 2;
			save.RestoreDirectory = true;

			if (save.ShowDialog() == DialogResult.OK)
			{
				string filePath = save.FileName;

				System.IO.File.WriteAllText(filePath, fileContent);
			}
			
			save.Dispose();
		}

		private void syntaxToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"drawTo <x>, <y> \n" +
				"moveTo<x>, < y > \n" +
				"rectangle<width>, < height >\n" +
				"circle < radius >\n" +
				"triangle < length >\n" +
				"pen<color> { black, white, red, green, blue }\n" +
				"fill < on / off >\n" +
				"reset\n" +
				"clear", 
				"Syntax."
			);
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Author: Zachery Barcoe\n" +
				"Website: https://zacherybarcoe.netlify.app/",
				"about."
			);
		}
	}
}