using System;

namespace Moxie.Shell
{
    public class ShellManager
    {
        #region Logs

        /// <summary>
        ///     Log only used for booting
        /// </summary>
        /// <param name="text">Text to output</param>
        /// <param name="type">Type of log. 1:PROCESS 2:DONE 3:FAILED</param>
        public void Log(string text, int type)
        {
            switch (type)
            {
                case 1:
                    Write("[ ");
                    Write("PROCESS", ConsoleColor.Blue);
                    Write(" ] " + text + "\n");
                    break;
                case 2:
                    Write("[ ");
                    Write("DONE", ConsoleColor.Green);
                    Write(" ] " + text + "\n");
                    break;
                case 3:
                    Write("[ ");
                    Write("FAILED", ConsoleColor.Red);
                    Write(" ] " + text + "\n");
                    break;
            }
        }

        #endregion

        #region Write

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="text">The text to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        /// <param name="type">Type of text 1:Process 2:Success 3:Error 4:Fatal</param>
        public void Write(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black, int type = 0)
        {
            switch (type)
            {
                case 0:
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Process
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("PROCESS:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Success
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("SUCCESS:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Error
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("ERROR:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Fatal
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write("FATAl:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }

        /// <summary>
        ///     Output text with color
        /// </summary>
        /// <param name="text">The text to output</param>
        /// <param name="foregroundColor">Change foreground text color</param>
        /// <param name="backgroundColor">Change background text color</param>
        /// <param name="type">Type of text 1:Process 2:Success 3:Error 4:Fatal</param>
        public void WriteLine(string text, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black, int type = 0)
        {
            switch (type)
            {
                case 0:
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.WriteLine(text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Process
                case 1:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("PROCESS:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Success
                case 2:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("SUCCESS:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Error
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("ERROR:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;

                //Fatal
                case 4:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write("FATAl:");
                    Console.ForegroundColor = foregroundColor;
                    Console.BackgroundColor = backgroundColor;
                    Console.Write(" " + text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
        }

        public void WriteChar(char character, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(character);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void WriteLineChar(char character, ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(character + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        #endregion
    }
}