using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
	public class CommandParser
	{
		Canvas canvas;

		public CommandParser(Canvas canvas)
		{
			this.canvas = canvas;
		}

		/// <summary>
		/// Command object with command word and arguments
		/// </summary>
		public class Command
        {
			public string Word;
			public string[] Args;

			public Command(string Word, string[] Args)
            {
                this.Word = Word;
                this.Args = Args;
            }

        }

		/// <summary>
		/// converts raw string into string array 
		/// splits at each new line and new line char trimmed
		/// </summary>
		/// <param name="raw"></param>
		/// <returns></returns>
		public static string[] RawStringToStringArray(string raw)
		{
			Console.WriteLine("running RawStringToStringArray...");
			string[] rawArray = raw.Split('\n');
			string[] stringArray = rawArray.Select(x => x.TrimEnd('\r', '\n', ' ')).ToArray();
			Console.WriteLine("RawStringToStringArray Done!");

			return stringArray;
		}

		/// <summary>
		/// splits command into command word and arguments
		/// </summary>
		/// <param name="rawCommand"></param>
		/// <returns></returns>
		public static Command ParseCommand(string rawCommand)
        {

			string[] rawArray = rawCommand.Split(' ');
			string[] args = rawArray.Select(x => x.TrimEnd(' ', ',')).ToArray();

			Command command = new Command(args[0], args.Skip(1).ToArray());

			return command;
		}

		/// <summary>
		/// converts raw string into array of commands
		/// </summary>
		/// <param name="rawProgram"></param>
		/// <returns></returns>
		public static Command[] RawStringToProgram(string rawProgram) 
		{
			string[] stringArray = RawStringToStringArray(rawProgram);
			Command[] program = new Command[stringArray.Length]; 

			Console.WriteLine("Parsing Commands...");
			for (int i = 0; i < stringArray.Length; i++)
            {
				program[i] = ParseCommand(stringArray[i]);
            }
			Console.WriteLine("Parsing Complete!");
			
			return program;
		}

		/// <summary>
		/// command parser taking a string 
		/// </summary>
		/// <param name="commandInput">command "command <arg1>... "</param>
		/// <exception cref="Exception"></exception>
		/// <todo>
		/// convert switch cases into class inhertience and create custom exception types
		/// </todo>
		public bool ParseSyntax(Command command)
		{
			
			switch (command.Word)
			{
				// circle <radius>
				case "circle":
					if (command.Args.Length != 1) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!int.TryParse(command.Args[0], out _)) throw new FormatException("argument 1 not a number");

					Console.WriteLine("drawing circle");
					canvas.DrawCircle(int.Parse(command.Args[0]));
					return true;
					

				// rectangle <width>, <height>
				case "rect":
					if (command.Args.Length != 2) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!int.TryParse(command.Args[0], out _)) throw new FormatException("argument 1 not a number");
					if (!int.TryParse(command.Args[1], out _)) throw new FormatException("argument 2 not a number");
					
					canvas.DrawRectangle(int.Parse(command.Args[0]), int.Parse(command.Args[1]));
					return true;

				// triangle <length>
				case "triangle":
					if (command.Args.Length != 1) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!int.TryParse(command.Args[0], out _)) throw new FormatException("argument 1 not a number");
					
					canvas.DrawTriangle(int.Parse(command.Args[0]));
					return true;

				// moveTo <x>, <y>
				case "moveTo":
					if (command.Args.Length != 2) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!int.TryParse(command.Args[0], out _)) throw new FormatException("argument 1 not a number");
					if (!int.TryParse(command.Args[1], out _)) throw new FormatException("argument 2 not a number");
					
					canvas.moveTo(int.Parse(command.Args[0]), int.Parse(command.Args[1]));
					return true;

				// drawTo <x>, <y>
				case "drawTo":
					if (command.Args.Length != 2) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!int.TryParse(command.Args[0], out _)) throw new FormatException("argument 1 not a number");
					if (!int.TryParse(command.Args[1], out _)) throw new FormatException("argument 2 not a number");
					
					canvas.DrawTo(int.Parse(command.Args[0]), int.Parse(command.Args[1]));
					return true;

				// pen <color>
				case "pen":
					string[] colors = { "black", "white", "red", "green", "blue" };

					if (command.Args.Length != 1) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!colors.Contains(command.Args[0])) throw new FormatException("not a valid color");
					
					canvas.ChangeColor(command.Args[0]);
					return true;

				// fill <on/off>
				case "fill":
					string[] options = { "on", "off" };

					if (command.Args.Length != 1) throw new ArgumentOutOfRangeException("incorrect number of arguments");

					if (!options.Contains(command.Args[0])) throw new FormatException("not a valid option");
					
					canvas.ChangeFill(command.Args[0] == "on");
					return true;

				// reset
				case "reset":
					if (command.Args.Length != 0) throw new ArgumentOutOfRangeException("incorrect number of arguments");
					
					canvas.Reset();
					return true;

				// clear
				case "clear":
					if (command.Args.Length != 0) throw new ArgumentOutOfRangeException("incorrect number of arguments");
					
					canvas.Clear();
					return true;

				// command not found
				default:
					throw new ArgumentException("Command Not Found");

			}

		}

		/// <summary>
		/// parses and runs program in raw string format
		/// </summary>
		/// <param name="rawString"></param>
		public void Run(string rawString)
        {
			Command[] program = RawStringToProgram(rawString);
			try 
			{ 
				foreach (Command command in program)
                {
					ParseSyntax(command);
                }
			}
			catch (Exception e) { throw e; }
        }
	}
}
