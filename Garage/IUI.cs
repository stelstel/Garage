using System;

namespace Garage
{
    public interface IUI
    {
        /// <summary>
        /// Reads input
        /// </summary>
        /// <returns>input</returns>
        string GetInput();

        /// <summary>
        /// Reads one character from input
        /// </summary>
        /// <returns>input as ConsoleKeyInfo</returns>
        public ConsoleKeyInfo ReadKey();

        /// <summary>
        /// Prints string
        /// </summary>
        /// <param name="message">String to print</param>
        void Print(string message);

        /// <summary>
        /// Prints string ending with line break
        /// </summary>
        /// <param name="message">String to print</param>
        void PrintLine(string message);

        /// <summary>
        /// Empties output screen
        /// </summary>
        void Clear();
    }
}
