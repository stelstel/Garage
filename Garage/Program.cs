namespace Garage
{
    class Program
    {
        private static UI ui { get; set; } = new UI();

        static void Main()
        {
            Menu.Run(ui);
        }
    }
}
