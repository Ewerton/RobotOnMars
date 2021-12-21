using RobotOnMars;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RobotOnMarsTests
{
    /// <summary>
    /// Tests related to the parsing of the string containing the commands to the robot
    /// </summary>
    public class RobotCommandsTests
    {
        [Fact]
        public void Test_ParsingEmptyStringOfCommands()
        {
            string testStr = "";
            var commands = new List<EnumRobotCommand>();

            // Testing Empty string
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == 0);
        }

        [Fact]
        public void Test_ParsingInvalidStringOfCommands()
        {
            string testStr = "ABC";
            var commands = new List<EnumRobotCommand>();

            // Testing Empty string
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == 0);
        }

        [Fact]
        public void Test_ParsingValidStringOfCommands()
        {
            string testStr = "";
            var commands = new List<EnumRobotCommand>();

            // Testing Left
            testStr = "L";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == testStr.Count());
            Assert.True(commands.Where(c => c == EnumRobotCommand.Left).Count() == 1);

            // Testing Left
            testStr = "R";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == testStr.Count());
            Assert.True(commands.Where(c => c == EnumRobotCommand.Right).Count() == 1);

            testStr = "F";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == testStr.Count());
            Assert.True(commands.Where(c => c == EnumRobotCommand.Front).Count() == 1);
        }

        [Fact]
        public void Test_ParsingRamdomStringOfCommands()
        {
            string testStr = "";
            var commands = new List<EnumRobotCommand>();

            // Testing Left
            testStr = "LLRRFF";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == 6);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Left).Count() == 2);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Right).Count() == 2);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Front).Count() == 2);

            // Testing with spaces
            testStr = "L R F";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == 3);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Left).Count() == 1);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Right).Count() == 1);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Front).Count() == 1);

            // Testing with mixed casing
            testStr = "L l R r F f";
            commands = RobotCommand.GetCommandsFromString(testStr);
            Assert.True(commands.Count == 6);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Left).Count() == 2);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Right).Count() == 2);
            Assert.True(commands.Where(c => c == EnumRobotCommand.Front).Count() == 2);
        }
    }
}