using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotOnMars
{
    public static class RobotCommand
    {
       public static List<EnumRobotCommand> GetCommandsFromString(string str)
        {
            str = str.Trim().ToUpper();
            List<EnumRobotCommand> lstRobotCommands = new List<EnumRobotCommand>();
            var strCommands = str.Where(s => s == 'L' || s == 'R' || s == 'F');

            foreach (var item in strCommands)
            {
                if (item == 'R')
                    lstRobotCommands.Add(EnumRobotCommand.Right);
                if (item == 'L')
                    lstRobotCommands.Add(EnumRobotCommand.Left);
                if (item == 'F')
                    lstRobotCommands.Add(EnumRobotCommand.Front);
            }

            return lstRobotCommands;
        }
    }
}
