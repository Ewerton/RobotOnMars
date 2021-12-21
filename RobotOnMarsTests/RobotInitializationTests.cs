using RobotOnMars;
using System;
using Xunit;

namespace RobotOnMarsTests
{
    /// <summary>
    /// Tests related to the initialization of the robot
    /// </summary>
    public class InitializationTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        public void Test_InvalidRobotInitialization(int plateauX, int plateauY)
        {
            Assert.Throws<ArgumentException>(() => new Robot(plateauX, plateauY));
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void Test_ValidRobotInitialization(int plateauX, int plateauY)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            Assert.True(r1.PositionX == 1, $"The starting X position of the robot should be 1");
            Assert.True(r1.PositionY == 1, $"The starting Y position of the robot should be 1");
            Assert.True(r1.PointingTo == EnumDirection.North, $"The starting pointing direction of the robot should be North");
        }


    }
}