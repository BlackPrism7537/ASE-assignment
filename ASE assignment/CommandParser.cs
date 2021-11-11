﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_assignment
{
    class CommandParser
    {
        /// <summary>
        /// command parser taking a string as input
        /// </summary>
        /// <param name="commandInput">command "command <arg1>... "</param>
        /// <exception cref="Exception"></exception>
        public void ParseCommand(String commandInput)
        {
            string[] rawArray = commandInput.Split(' ');
            string[] args = rawArray.Select(x => x.TrimEnd(' ', ',')).ToArray();

            switch (args[0])
            {
                // circle <radius>
                case "circle":
                    if (args.Length != 2) throw new Exception("incorrect number of params");
                    if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
                    Console.WriteLine("draw circle with radius" + args[1]);
                    break;

                // rectangle <width>, <height>
                case "rectangle":
                    if (args.Length != 3) throw new Exception("incorrect number of params");
                    if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
                    if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
                    Console.WriteLine("draw rectangle with width" + args[1] + "and height" + args[2]);
                    break;

                // triangle <length>
                case "triangle":
                    if (args.Length != 2) throw new Exception("incorrect number of params");
                    if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
                    Console.WriteLine("draw triangle with side length" + args[1]);
                    break;

                // moveTo <x>, <y>
                case "moveTo":
                    if (args.Length != 3) throw new Exception("incorrect number of params");
                    if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
                    if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
                    Console.WriteLine("move pen to x" + args[1] + "and y" + args[2]);
                    break;

                // drawTo <x>, <y>
                case "drawTo":
                    if (args.Length != 3) throw new Exception("incorrect number of params");
                    if (!int.TryParse(args[1], out _)) throw new Exception("Param 0 not a number");
                    if (!int.TryParse(args[2], out _)) throw new Exception("Param 1 not a number");
                    Console.WriteLine("draw to x" + args[1] + "and y" + args[2]);
                    break;

                // pen <color>
                case "pen":
                    string[] colors = { "black", "white", "red", "green", "blue" };
                    if (args.Length != 2) throw new Exception("incorrect number of params");
                    if (!colors.Contains(args[1])) throw new Exception("not valid color");
                    Console.WriteLine("set pen color to" + args[1]);
                    break;

                // fill <on/off>
                case "fill":
                    string[] options = { "on", "off" };
                    if (args.Length != 2) throw new Exception("incorrect number of params");
                    if (!options.Contains(args[1])) throw new Exception("not valid option");
                    Console.WriteLine("set fill to" + args[1]);
                    break;

                // reset
                case "reset":
                    if (args.Length != 1) throw new Exception("incorrect number of params");
                    Console.WriteLine("reset pen position");
                    break;

                // clear
                case "clear":
                    if (args.Length != 1) throw new Exception("incorrect number of params");
                    Console.WriteLine("clear canvas");
                    break;

                // command not found
                default:
                    throw new Exception("command not found");

            }
        }
    }
}