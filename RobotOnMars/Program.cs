using RobotOnMars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotOnMars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] arrPlateauSize = ReadPlateauSize();
            List<EnumRobotCommand> commandsList = ReadRobotCommands();

            Robot curiosity = new Robot(int.Parse(arrPlateauSize[0]), int.Parse(arrPlateauSize[1]));

            Console.WriteLine($"  Robot Starting Status: Position [{curiosity.PositionX},{curiosity.PositionY}] Direction: {curiosity.PointingTo}");
            foreach (EnumRobotCommand command in commandsList)
            {
                curiosity.ExecuteMovement(command);

                Console.WriteLine($"    {command.GetDescription()}  --> Current status: Position [{curiosity.PositionX},{curiosity.PositionY}] Direction: {curiosity.PointingTo}");
            }
            Console.WriteLine($"  Robot Ending Status: Position [{curiosity.PositionX},{curiosity.PositionY}] Direction: {curiosity.PointingTo}");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }

        private static string[] ReadPlateauSize()
        {
            Console.WriteLine("Please, type the size of the plateau. e.g: 5x5");
            var inputPlateauSize = Console.ReadLine();

            return ParsePlateauSize(inputPlateauSize);
        }


        private static string[] ParsePlateauSize(string? inputPlateauSize)
        {
            if (String.IsNullOrWhiteSpace(inputPlateauSize))
                throw new Exception("The plateau size is required.");

            var plateauArray = inputPlateauSize.ToUpper().Split('X');

            if (plateauArray == null)
                throw new Exception("The plateau size was typed in an invalid format. Try to type: 5x5, 3x4, 2x2, etc.");

            if (plateauArray.Count() > 2)
                throw new Exception("The plateau size was typed in an invalid format. Try to type: 5x5, 3x4, 2x2, etc.");

            if (plateauArray.Count() < 2)
                throw new Exception("The plateau size was typed in an invalid format. Try to type: 5x5, 3x4, 2x2, etc.");

            return plateauArray;
        }

        private static List<EnumRobotCommand> ReadRobotCommands()
        {
            Console.WriteLine("Please, type the list of commands for the robot. e.g: FFRFLFLF");
            var inputRobotCommands = Console.ReadLine();
            return ParseRobotCommands(inputRobotCommands);
        }

        private static List<EnumRobotCommand> ParseRobotCommands(string? inputRobotCommands)
        {
            if (String.IsNullOrWhiteSpace(inputRobotCommands))
                throw new Exception("The list of commands for the robot is required.");

            var lstCommands = RobotCommand.GetCommandsFromString(inputRobotCommands);

            if (lstCommands.Count <= 0)
                throw new Exception("Invalid robot commands parameter.");

            return lstCommands;
        }
    }
}