using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotOnMars
{
    public class Robot
    {
        public EnumDirection PointingTo { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        private int PlateauX { get; set; }
        private int PlateauY { get; set; }

        public Robot(int plateauX, int plateauY)
        {
            if (plateauX <= 0 || plateauY <= 0)
                throw new ArgumentException($"Invalid plateau size. It must be greater than [Zero, Zero].");

            PointingTo = EnumDirection.North;
            PositionX = 1;
            PositionY = 1;

            PlateauX = plateauX;
            PlateauY = plateauY;
        }

        public bool ExecuteMovement(EnumRobotCommand command)
        {
            switch (command)
            {
                case EnumRobotCommand.Front:
                    return MoveFront();

                case EnumRobotCommand.Left:
                    TurnLeft();
                    return true;

                case EnumRobotCommand.Right:
                    TurnRight();
                    return true;
            }

            return false;
        }

        public bool MoveFront()
        {
            if (CanMove())
            {
                switch (PointingTo)
                {
                    case EnumDirection.North:
                        PositionY = PositionY + 1;
                        break;
                    case EnumDirection.South:
                        PositionY = PositionY - 1;
                        break;
                    case EnumDirection.East:
                        PositionX = PositionX + 1;
                        break;
                    case EnumDirection.West:
                        PositionX = PositionX - 1;
                        break;
                    default:
                        break;
                }
                return true;
            }
            return false;
        }

        public void TurnRight()
        {
            switch (PointingTo)
            {
                case EnumDirection.North:
                    PointingTo = EnumDirection.East;
                    break;
                case EnumDirection.East:
                    PointingTo = EnumDirection.South;
                    break;
                case EnumDirection.South:
                    PointingTo = EnumDirection.West;
                    break;
                case EnumDirection.West:
                    PointingTo = EnumDirection.North;
                    break;
                default:
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (PointingTo)
            {
                case EnumDirection.North:
                    PointingTo = EnumDirection.West;
                    break;
                case EnumDirection.West:
                    PointingTo = EnumDirection.South;
                    break;
                case EnumDirection.South:
                    PointingTo = EnumDirection.East;
                    break;
                case EnumDirection.East:
                    PointingTo = EnumDirection.North;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Check if the robot can move in the plateau
        /// </summary>
        /// <returns></returns>
        private bool CanMove()
        {
            switch (PointingTo)
            {
                case EnumDirection.North:
                    return (PositionY + 1 <= PlateauY);

                case EnumDirection.East:
                    return (PositionX + 1 <= PlateauX);

                case EnumDirection.South:
                    return ((PositionY - 1 <= PlateauY) &&
                            (PositionY - 1 > 0));

                case EnumDirection.West:
                    return ((PositionX - 1 <= PlateauX) &&
                            (PositionX - 1 > 0));
            }

            return false;
        }

    }
}
