using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotOnMars
{
    /// <summary>
    /// Represents the direction a robot can turn
    /// </summary>
    public enum EnumDirection
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }

    /// <summary>
    /// Represent a command accepted by the robot
    /// </summary>
    public enum EnumRobotCommand
    {
        [Description("Moving to front")]
        Front = 0,

        [Description("Turning to Left")]
        Left = 1,

        [Description("Turning to Right")]
        Right = 2,
    }

    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            string description = String.Empty;

            if (!typeof(T).IsEnum)
                return String.Empty;

            description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}
