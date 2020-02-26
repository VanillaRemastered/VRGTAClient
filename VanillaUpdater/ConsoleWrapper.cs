using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanillaUpdater
{
    class ConsoleWrapper
    {
        public enum PrintStatus
        {
            Normal = 0,
            Error = 1,
            Warning = 2
        }

        public static void PrintColorMessage(string msg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

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
        public static void PrintMessage(string msg, PrintStatus p)
        {
            switch(p)
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
