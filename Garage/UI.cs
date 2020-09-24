using System;

namespace Garage
{
    /// <summary>
    /// Prints to and reads
    /// </summary>
    internal class UI : IUI
    {
        readonly ConsoleUI consoleUI = new ConsoleUI();

        /// <summary>
        /// Reads input
        /// </summary>
        /// <returns>input string</returns>
        public string GetInput()
        {
            return consoleUI.GetInput();
        }

        /// <summary>
        /// Reads one character from input
        /// </summary>
        /// <returns>input as ConsoleKeyInfo</returns>
        public ConsoleKeyInfo ReadKey()
        {
            return consoleUI.ReadKey();
        }


        /// <summary>
        /// Prints string
        /// </summary>
        /// <param name="message">string to print</param>
        public void Print(string message = "")
        {
            consoleUI.Print(message);
        }

        /// <summary>
        /// Prints string ending with line break
        /// </summary>
        /// <param name="message">string to print</param>
        public void PrintLine(string message = "")
        {
            consoleUI.PrintLine(message);
        }

        /// <summary>
        /// Empties screen
        /// </summary>
        public void Clear()
        {
            consoleUI.Clear();
        }
    }
}