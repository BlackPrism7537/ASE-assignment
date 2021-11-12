using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_assignment;

namespace ASE_assignment_Test
{
    [TestClass]
    public class CommandParserTest
    {
        [TestMethod]
        public void RawStringToProgram_withValidString()
        {
            //arrange
            string rawInput = "circle 100\nrectangle 10, 10\nreset";
            string[] expected = {
                "circle 100",
                "rectangle 10, 10",
                "reset"
            };

            //act
            string[] output = CommandParser.RawStringToProgram(rawInput);


            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i] == output[i], "output didn't match");
            }
        }

        [TestMethod]
        public void RawStringToProgram_withEmptyString()
        {
            //arrange
            string rawInput = string.Empty;
            string[] expected = {""};

            //act
            string[] output = CommandParser.RawStringToProgram(rawInput);

            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i] == output[i], "output didn't match");
            }
        }

        [TestMethod]
        public void ParseArguments_withValidString()
        {
            //arrange
            string rawInput = "circle 100";
            string[] expected = { "circle", "100" };

            //act
            string[] output = CommandParser.ParseArguments(rawInput);

            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i] == output[i], "output didn't match");
            }
        }

        [TestMethod]
        public void ParseArguments_withEmptyString()
        {
            //arrange
            string rawInput = string.Empty;
            string[] expected = {""};

            //act
            string[] output = CommandParser.ParseArguments(rawInput);

            //assert
            Assert.IsTrue(output.Length == expected.Length, "output notexpected length");

            for (int i = 0; i < output.Length; i++)
            {
                Assert.IsTrue(expected[i] == output[i], "output didn't match");
            }
        }

    }
}
