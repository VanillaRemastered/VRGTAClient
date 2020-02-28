using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAClientUpdater
{
    class ConsoleWrapper
    {
        public enum PrintStatus
        {
            Normal = 0,
            Error = 1,
            Warning = 2
        }

        /// <summary>
        /// Prints colored message in the terminal/pip'd output.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="color"></param>
        public static void PrintColorMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints text 'VR' in ASCII to console.
        /// </summary>
        public static void PrintAsciiSignature()
        {
            Console.WriteLine(@" ___      ___ ________     
                                |\  \    /  /|\   __  \    
                                \ \  \  /  / | \  \|\  \   
                                 \ \  \/  / / \ \   _  _\  
                                  \ \    / /   \ \  \\  \|
                                   \ \__ / /     \ \__\\ _\ 
                                    \| __ |/       \| __ |\| __ |
                        ");
        }

        /// <summary>
        /// Prints a message based on PrintStatus.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="p"></param>
        public static void PrintMessage(string msg, PrintStatus p)
        {
            switch (p)
            {
                case PrintStatus.Error:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[! ! !] ERROR: " + msg);
                        Console.ResetColor();
                        break;
                    }
                case PrintStatus.Warning:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("[! ! !] WARNING: " + msg);
                        Console.ResetColor();
                        break;
                    }
                case PrintStatus.Normal:
                    {
                        Console.WriteLine("[>] " + msg);
                        break;
                    }

            }
        }
    }
}
