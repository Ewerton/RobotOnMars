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
    /// Tests related to the turning movement
    /// </summary>
    public class RobotTurningTests
    {
        [Theory]
        [InlineData(EnumDirection.North)]
        [InlineData(EnumDirection.East)]
        [InlineData(EnumDirection.South)]
        [InlineData(EnumDirection.West)]
        public void Test_TurnLeft(EnumDirection currentlyPointingTo)
        {
            Robot r1 = new Robot(1, 1);
            r1.PointingTo = currentlyPointingTo;
            r1.TurnLeft();

            switch (currentlyPointingTo)
            {
                case EnumDirection.North:
                    Assert.True(r1.PointingTo == EnumDirection.West);
                    break;
                case EnumDirection.West:
                    Assert.True(r1.PointingTo == EnumDirection.South);
                    break;
                case EnumDirection.South:
                    Assert.True(r1.PointingTo == EnumDirection.East);
                    break;
                case EnumDirection.East:
                    Assert.True(r1.PointingTo == EnumDirection.North);
                    break;
                default:
                    break;
            }
        }


        [Theory]
        [InlineData(EnumDirection.North)]
        [InlineData(EnumDirection.East)]
        [InlineData(EnumDirection.South)]
        [InlineData(EnumDirection.West)]
        public void Test_TurnRight(EnumDirection currentlyPointingTo)
        {
            Robot r1 = new Robot(1, 1);
            r1.PointingTo = currentlyPointingTo;
            r1.TurnRight();

            switch (currentlyPointingTo)
            {
                case EnumDirection.North:
                    Assert.True(r1.PointingTo == EnumDirection.East);
                    break;
                case EnumDirection.East:
                    Assert.True(r1.PointingTo == EnumDirection.South);
                    break;
                case EnumDirection.South:
                    Assert.True(r1.PointingTo == EnumDirection.West);
                    break;
                case EnumDirection.West:
                    Assert.True(r1.PointingTo == EnumDirection.North);
                    break;              
               
                default:
                    break;
            }
        }

    }
}
