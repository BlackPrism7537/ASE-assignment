using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_assignment
{
	public partial class MainWindow : Form
	{

		private CommandParser parser;
		private Canvas canvas;
		private Bitmap bitmap = new Bitmap(300, 300);

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
		public void RunCommandLine(string command, CommandParser parser)
		{
			try
			{
				parser.Run(command);
				this.pictureBox1.Refresh();
			} catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!");
			}
				
		}

		/// <summary>
		/// Get Method for the command parser
		/// </summary>
		/// <returns>current command parser</returns>
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
			try
			{
				parser.Run(rawInput);
				this.pictureBox1.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!");
			}
		}

		/// <summary>
		/// checks the keycode of the key press event is the enter key
		/// if the command is run then runs the program or instead runs the command through the parser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CommandLine_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (this.CommandLine.Text == "run") RunProgram(this.ProgramInput.Text, GetParser());
				else RunCommandLine(this.CommandLine.Text, GetParser());
				this.CommandLine.Text = "";
			}
		}

		/// <summary>
		/// if the command is run then runs the program or instead runs the command through the parser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RunCommandButton_Click(object sender, EventArgs e)
		{
			if(this.CommandLine.Text == "run") RunProgram(this.ProgramInput.Text, GetParser());
			else RunCommandLine(this.CommandLine.Text, GetParser());
			this.CommandLine.Text = "";
		}

		/// <summary>
		/// runs program on click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RunProgramButton_Click(object sender, EventArgs e)
		{
			RunProgram(this.ProgramInput.Text, GetParser());
		}

		/// <summary>
		/// repaints the pictureBox1 when it's Paint event is called
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImageUnscaled(this.bitmap, 0, 0);
			Console.WriteLine("image reloaded");
		}

		/// <summary>
		/// opens the open file dialog, when the user selects a text 
		/// file the contents of the text file is set as the program 
		/// inputs text
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// opens the save file dialog, when the user selects a text 
		/// file the contents of the program input is saved to the 
		/// text file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// opens message box with the available syntax
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// opens message box with the about information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
