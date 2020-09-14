using System;

namespace Garage
{
    /// <summary>
    /// Prints to and reads from Console
    /// </summary>
    public class ConsoleUI : IUI
    {
        /// <summary>
        /// Reads input from Console
        /// </summary>
        /// <returns>User input</returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints string to Console
        /// </summary>
        /// <param name="message">string to print</param>
        public void Print(string message)
        {
            Console.Write(message);
        }

        /// <summary>
        /// Prints string to Console ending with line break
        /// </summary>
        /// <param name="message">string to print</param>
        public void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Empties console
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }
    }
}
