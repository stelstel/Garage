namespace Garage
{
    /// <summary>
    /// Prints to and reads
    /// </summary>
    public class UI : IUI
    {
        readonly ConsoleUI consoleUI = new ConsoleUI();

        /// <summary>
        /// Reads input
        /// </summary>
        /// <returns>input</returns>
        public string GetInput()
        {
            return consoleUI.GetInput();
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
        public void PrintLine(string message)
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