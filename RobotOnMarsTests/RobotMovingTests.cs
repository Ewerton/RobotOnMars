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
    /// Tests related to the robot movement
    /// </summary>
    public class RobotMovingTests
    {
        [Theory]
        [InlineData(EnumRobotCommand.Front)]
        [InlineData(EnumRobotCommand.Left)]
        [InlineData(EnumRobotCommand.Right)]
        public void Test_ExecuteMovementFuntion(EnumRobotCommand command)
        {
            Robot r1 = new Robot(2, 2);
            Assert.True(r1.ExecuteMovement(command));
        }

        [Theory]
        [InlineData(1, 1, EnumDirection.North)]
        [InlineData(1, 1, EnumDirection.East)]
        [InlineData(1, 1, EnumDirection.South)]
        [InlineData(1, 1, EnumDirection.West)]
        public void Test_MoveNonExistingPosition(int plateauX, int plateauY, EnumDirection currentlyPointingTo)
        {
            // 1x1 plateau, the robot cannot regardless of its direction.
            Robot r1 = new Robot(plateauX, plateauY);
            r1.PointingTo = currentlyPointingTo;
            Assert.False(r1.MoveFront(), $"The robot cannot move in an [{plateauX} x {plateauY}] plateau.");
            Assert.True(r1.PositionX == 1, $"The robot should not move in a [{plateauX} x {plateauY}] plateau.");
            Assert.True(r1.PositionY == 1, $"The robot should not move in a [{plateauX} x {plateauY}] plateau.");
        }

        [Theory]
        [InlineData(2, 2)]
        public void Test_MoveInSquareShape(int plateauX, int plateauY)
        {
            // Move the robot in square shape (clockwise)
            Robot r1 = new Robot(plateauX, plateauY);

            // Starting at [1,1]
            Assert.True(r1.PositionX == 1, $"The robot was initialized at the wrong position. It should be [1,1]");
            Assert.True(r1.PositionY == 1, $"The robot was initialized at the wrong position. It should be [1,1]");

            // Going to North
            r1.MoveFront();
            Assert.True(r1.PositionX == 1, $"The robot cannot move in X axis at this step.");
            Assert.True(r1.PositionY == 2, $"The robot should move in Y axis at this step.");

            // Turning to East
            r1.TurnRight();
            Assert.True(r1.PositionX == 1, $"The robot cannot move when turning to left.");
            Assert.True(r1.PositionY == 2, $"The robot cannot move when turning to left.");

            // Moving to the Left
            r1.MoveFront();
            Assert.True(r1.PositionX == 2, $"The robot should move in X axis at this step.");
            Assert.True(r1.PositionY == 2, $"The robot cannot move in Y axis at this step.");

            // Turning to South
            r1.TurnRight();
            Assert.True(r1.PositionX == 2, $"The robot cannot move when turning to south.");
            Assert.True(r1.PositionY == 2, $"The robot cannot move when turning to south.");

            // Moving to the South
            r1.MoveFront();
            Assert.True(r1.PositionX == 2, $"The robot cannot move in X axis at this step.");
            Assert.True(r1.PositionY == 1, $"The robot should move in Y axis at this step.");

            // Turning to West
            r1.TurnRight();
            Assert.True(r1.PositionX == 2, $"The robot cannot move when turning to West.");
            Assert.True(r1.PositionY == 1, $"The robot cannot move when turning to West.");

            // Moving to the West
            r1.MoveFront();
            Assert.True(r1.PositionX == 1, $"The robot should move in X axis at this step.");
            Assert.True(r1.PositionY == 1, $"The robot cannot move in Y axis at this step.");
        }

        [Theory]
        [InlineData(2, 2)]
        public void Test_MoveAwayGoingToNorth(int plateauX, int plateauY)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            r1.PointingTo = EnumDirection.North;
            Assert.True(r1.MoveFront()); // Valid movement
            Assert.False(r1.MoveFront()); // Invalid movement
        }

        [Theory]
        [InlineData(2, 2)]
        public void Test_MoveAwayGoingEast(int plateauX, int plateauY)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            r1.PointingTo = EnumDirection.East;
            Assert.True(r1.MoveFront());
            Assert.False(r1.MoveFront());
        }

        [Theory]
        [InlineData(2, 2)]
        public void Test_MoveAwayGoingSouth(int plateauX, int plateauY)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            r1.PointingTo = EnumDirection.South;
            Assert.False(r1.MoveFront());
        }

        [Theory]
        [InlineData(2, 2)]
        public void Test_MoveAwayGoingWest(int plateauX, int plateauY)
        {
            Robot r1 = new Robot(plateauX, plateauY);
            r1.PointingTo = EnumDirection.West;
            Assert.False(r1.MoveFront());
        }

       

    }
}
