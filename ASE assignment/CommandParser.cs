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
		/// converts raw string into string array 
		/// splits at each new line and new line char trimmed
		/// </summary>
		/// <param name="raw"></param>
		/// <returns></returns>
		public static string[] RawStringToProgram(string raw)
		{
			string[] rawArray = raw.Split('\n');
			string[] Program = rawArray.Select(x => x.TrimEnd('\r', '\n', ' ')).ToArray();

			return Program;
		}

		/// <summary>
		/// splits command into command word and arguments
		/// </summary>
		/// <param name="rawCommand"></param>
		/// <returns></returns>
		public static string[] ParseArguments(string rawCommand)
        {
			string[] rawArray = rawCommand.Split(' ');
			string[] args = rawArray.Select(x => x.TrimEnd(' ', ',')).ToArray();

			return args;
		}

		/// <summary>
		/// command parser taking a string as input
		/// </summary>
		/// <param name="commandInput">command "command <arg1>... "</param>
		/// <exception cref="Exception"></exception>
		public void ParseCommand(String commandInput)
		{
			string[] args = ParseArguments(commandInput);

			switch (args[0])
			{
				// circle <radius>
				case "circle":
					if (args.Length != 2) throw new Exception("incorrect number of params");
					if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
					Console.WriteLine("draw circle with radius" + args[1]);
					canvas.DrawCircle(int.Parse(args[1]));
					break;

				// rectangle <width>, <height>
				case "rectangle":
					if (args.Length != 3) throw new Exception("incorrect number of params");
					if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
					if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
					Console.WriteLine("draw rectangle with width" + args[1] + "and height" + args[2]);
					canvas.DrawRectangle(int.Parse(args[1]), int.Parse(args[2]));
					break;

				// triangle <length>
				case "triangle":
					if (args.Length != 2) throw new Exception("incorrect number of params");
					if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
					Console.WriteLine("draw triangle with side length" + args[1]);
					canvas.DrawTriangle(int.Parse(args[1]));
					break;

				// moveTo <x>, <y>
				case "moveTo":
					if (args.Length != 3) throw new Exception("incorrect number of params");
					if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
					if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
					Console.WriteLine("move pen to x" + args[1] + "and y" + args[2]);
					canvas.moveTo(int.Parse(args[1]), int.Parse(args[2]));
					break;

				// drawTo <x>, <y>
				case "drawTo":
					if (args.Length != 3) throw new Exception("incorrect number of params");
					if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
					if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
					Console.WriteLine("draw to x" + args[1] + "and y" + args[2]);
					canvas.DrawTo(int.Parse(args[1]), int.Parse(args[2]));
					break;

				// pen <color>
				case "pen":
					string[] colors = { "black", "white", "red", "green", "blue" };
					if (args.Length != 2) throw new Exception("incorrect number of params");
					if (!colors.Contains(args[1])) throw new Exception("not valid color");
					Console.WriteLine("set pen color to" + args[1]);
					canvas.ChangeColor(args[1]);
					break;

				// fill <on/off>
				case "fill":
					string[] options = { "on", "off" };
					if (args.Length != 2) throw new Exception("incorrect number of params");
					if (!options.Contains(args[1])) throw new Exception("not valid option");
					Console.WriteLine("set fill to" + args[1]);
					if (args[1] == "on") canvas.ChangeFill(true);
					else canvas.ChangeFill(false);
					break;

				// reset
				case "reset":
					if (args.Length != 1) throw new Exception("incorrect number of params");
					Console.WriteLine("reset pen position");
					canvas.reset();
					break;

				// clear
				case "clear":
					if (args.Length != 1) throw new Exception("incorrect number of params");
					Console.WriteLine("clear canvas");
					canvas.clear();
					break;

				// command not found
				default:
					throw new Exception("command not found");

			}
		}
	}
}
