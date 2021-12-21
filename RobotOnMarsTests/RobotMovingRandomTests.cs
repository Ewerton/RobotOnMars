using RobotOnMars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RobotOnMarsTests
{
    /// <summary>
    /// Various random movements tests
    /// </summary>
    public class RobotMovingRandomTests
    {
        [Theory]
        [InlineData(5, 5, "FFRFLFLF")]
        public void Test_MoveExample1(int plateauX, int plateauY, string strCommands)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            var commands = RobotCommand.GetCommandsFromString(strCommands);

            foreach (var item in commands)
            {
                switch (item)
                {
                    case EnumRobotCommand.Front:
                        r1.MoveFront();
                        break;
                    case EnumRobotCommand.Left:
                        r1.TurnLeft();
                        break;
                    case EnumRobotCommand.Right:
                        r1.TurnRight();
                        break;
                    default:
                        break;
                }
            }

            Assert.True(r1.PositionX == 1, $"The robot does not ended in the desired X position.");
            Assert.True(r1.PositionY == 4, $"The robot does not ended in the desired Y position.");
            Assert.True(r1.PointingTo == EnumDirection.West, $"The robot does not ended te movement pointing to West.");
        }


    }
}
