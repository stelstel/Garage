﻿using System;

namespace Garage
{
    class Program
    {
        public static UI Ui { get; set; } = new UI();
        //public static Garage<Vehicle> Garage { get; set; }

        static void Main()
        {
            //GarageHandler garageHandler = new GarageHandler();
            Menu.Run();
        }
    }
}
