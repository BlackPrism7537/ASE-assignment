using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_assignment;
using System;

namespace ASE_assignment_Test
{
    [TestClass]
    public class CommandParserTest
    {

        /// <summary>
        /// tests the RawStringToProgram method with valid string input
        /// </summary>
        [TestMethod]
        public void RawStringToProgram_withValidString()
        {
            //arrange
            string rawInput = "circle 100\nrectangle 10, 10\nreset";
            CommandParser.Command[] expected = {
                new ("circle", new string[] {"100"}),
                new ("rectangle", new string[] {"10", "10"}),
                new ("reset", System.Array.Empty<string>())
            };
                

            //act
            CommandParser.Command[] output = CommandParser.RawStringToProgram(rawInput);


            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i].Word == output[i].Word, "output command word didn't match");
                for (int j = 0; j < output[i].Args.Length; j++)
                {
                    Assert.AreEqual(expected[i].Args[j], output[i].Args[j], "output arguments didnt match");
                }
            }
        }

        /// <summary>
        /// tests the RawStringToProgram method with empty string input
        /// </summary>
        [TestMethod]
        public void RawStringToProgram_withEmptyString()
        {
            //arrange
            string rawInput = string.Empty;
            CommandParser.Command[] expected = { new("", System.Array.Empty<string>()) };

            //act
            CommandParser.Command[] output = CommandParser.RawStringToProgram(rawInput);

            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i].Word == output[i].Word, "output command word didn't match");
                for (int j = 0; j < output[i].Args.Length; j++)
                {
                    Assert.AreEqual(expected[i].Args[j], output[i].Args[j], "output arguments didnt match");
                }
            }
        }


        /// <summary>
        /// tests the ParseCommand method with valid string input
        /// </summary>
        [TestMethod]
        public void ParseCommand_withValidString()
        {
            //arrange
            string rawInput = "circle 100";
            CommandParser.Command expected = new ("circle", new string[] { "100" });

            //act
            CommandParser.Command output = CommandParser.ParseCommand(rawInput);

            //assert
            Assert.AreEqual(expected.Word, output.Word, "Command words did not match");
            Assert.IsTrue(output.Args.Length == expected.Args.Length, "output arguments not expected length");

            for (int i = 0; i < output.Args.Length; i++)
            {
                Assert.IsTrue(expected.Args[i] == output.Args[i], "output arguments didn't match");
            }
        }

        /// <summary>
        /// tests the ParseCommand method with empty string input
        /// </summary>
        [TestMethod]
        public void ParseCommand_withEmptyString()
        {
            //arrange
            string rawInput = string.Empty;
            CommandParser.Command expected = new("", System.Array.Empty<string>());
                
            //act
            CommandParser.Command output = CommandParser.ParseCommand(rawInput);

            //assert
            Assert.AreEqual(expected.Word, output.Word, "Command words did not match");
            Assert.IsTrue(output.Args.Length == expected.Args.Length, "output arguments not expected length");

            for (int i = 0; i < output.Args.Length; i++)
            {
                Assert.IsTrue(expected.Args[i] == output.Args[i], "output arguments didn't match");
            }
        }

        /// <summary>
        /// tests the ParseSyntax method with all valid command words and valid arguments
        /// </summary>
        [TestMethod]
        public void ParseSyntax_withValidCommands()
        {
            //arrange
            CommandParser parser = new(new Canvas());
            CommandParser.Command[] commands = { 
                new("circle", new[] { "100" }),
                new("rect", new[] {"10", "10"}),
                new("triangle", new[] {"10"}),
                new("moveTo", new[] {"10", "10"}),
                new("drawTo", new[] {"10", "10"}),
                new("pen", new[] {"red"}),
                new("fill", new[] {"on"}),
                new("reset", System.Array.Empty<string>()),
                new("clear", System.Array.Empty<string>())
            };

            foreach (CommandParser.Command command in commands)
            {
                //act
                bool output = parser.ParseSyntax(command);

                //assert
                Assert.IsTrue(output, string.Format("Command: {0} failed to parse", command.Word));
            }
        }

        /// <summary>
        /// tests the ParseSyntax method with an invalid command word 
        /// triggering an Argument Exception
        /// </summary>
        [TestMethod]
        public void ParseSyntax_withInvalidCommand()
        {
            //arrange
            CommandParser parser = new(new Canvas());
            CommandParser.Command command = new("not a command", new[] { "1" });

            //act/assert
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseSyntax(command), 
                "Invalid Command did not throw an exception"
            );
        }

        /// <summary>
        /// tests the ParseSyntax method with an invalid argument length 
        /// triggering an Argument Out Of Range Exception
        /// </summary>
        [TestMethod]
        public void ParseSyntax_withInvalidArgumentLength()
        {
            //arrange
            CommandParser parser = new(new Canvas());
            CommandParser.Command command = new("circle", new[] { "1", "2" });

            //act/assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => parser.ParseSyntax(command),
                "Invalid argument length did not throw an exception"
            );
        }

        /// <summary>
        /// tests the ParseSyntax method with an invalid argument type 
        /// triggering a Format Exception
        /// </summary>
        [TestMethod]
        public void ParseSyntax_withInvalidArgumentType()
        {
            //arrange
            CommandParser parser = new(new Canvas());
            CommandParser.Command command = new("circle", new[] { "b" });

            //act/assert
            Assert.ThrowsException<FormatException>(
                () => parser.ParseSyntax(command),
                "Invalid argument type did not throw an exception"
            );
        }


        [TestMethod]
        public void ParseSyntax_Variables_withValidInput()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod]
        public void ParseSyntax_Variables_withInvalidInput()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod]
        public void ParseSyntax_Methods_withValidInput()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod]
        public void ParseSyntax_Methods_withInvalidInput()
        {
            Assert.Fail("Not Implemented");
        }





    }
}
