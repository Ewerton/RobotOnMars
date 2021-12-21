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
    public class GeneralTests
    {
        [Fact]
        public void Test_GetDescriptionEnumRobotCommand()
        {
            EnumRobotCommand cFront = EnumRobotCommand.Front;
            Assert.True(cFront.GetDescription() == "Moving to front");

            EnumRobotCommand cLeft = EnumRobotCommand.Left;
            Assert.True(cLeft.GetDescription() == "Turning to Left");

            EnumRobotCommand cRight = EnumRobotCommand.Right;
            Assert.True(cRight.GetDescription() == "Turning to Right");
        }
    }
}