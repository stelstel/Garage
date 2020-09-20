using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        #region Properties **************************************************************

        private Vehicle[] vehicles;

        public object Current => throw new NotImplementedException();
        #endregion


        #region Constructors ************************************************************
        public Garage(int numberOfParkingSpaces)
        {
            vehicles = new Vehicle[numberOfParkingSpaces];
        }
        #endregion


        #region Methods *****************************************************************

        public void ParkVehicle(Vehicle vehicle) // TODO if no spaces left???
        {
            foreach (Vehicle veh in vehicles)
            {
                if (veh != null)
                {
                    // Vehicle with the same registration number is already parked
                    if (veh.RegistrationNumber == vehicle.RegistrationNumber)
                    {
                        throw new ArgumentException($"A vehicle with the registration number {veh.RegistrationNumber} is already parked in the garage");
                    }
                }
            }

            int firstEmptyArraySpace = Array.IndexOf(vehicles, null);
            vehicles[firstEmptyArraySpace] = vehicle;
        }


        public bool UnparkVehicle(string regNum)
        {
            bool unparkingSuccess = false;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                if (regNum == vehicles[i]?.RegistrationNumber)
                {
                    vehicles[i] = null;
                    unparkingSuccess = true;
                }
            }
            return unparkingSuccess;
        }

        /// <summary>
        ///     Creates a string containing of parked vehicles
        /// </summary>
        /// <returns>String containing parked vehicles</returns>
        public string ListParkedVehicles()
        {
            StringBuilder output = new StringBuilder("Vehicles in garage:\n-------------------------------------------------------------\n");

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    output.Append(vehicle.ToString());
                    output.Append("\n");
                }
            }
            return output.ToString();
        }

        public string[] ListParkedVehiclesColours()
        {
            HashSet<string> colourSet = new HashSet<string>();

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    colourSet.Add(vehicle.Colour);
                }
            }

            string[] colourArr = colourSet.ToArray();

            return colourArr;
        }


        public string ListParkedVehiclesByType()
        {
            StringBuilder output = new StringBuilder("Vehicles in garage, by type:\n-------------------------------------------------------------\n");
            Dictionary<string, int> typeNumberDict = new Dictionary<string, int>();


            typeNumberDict.Add("Airplane", 0);
            typeNumberDict.Add("Boat", 0);
            typeNumberDict.Add("Bus", 0);
            typeNumberDict.Add("Car", 0);
            typeNumberDict.Add("Motorcycle", 0);

            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    for (int i = 0; i < typeNumberDict.Count; i++)
                    {
                        // Vehicle in garage == vehicle in the list counting different types of vehicles
                        if (String.Equals(vehicle.GetType().Name, typeNumberDict.ElementAt(i).Key))
                        {
                            typeNumberDict[typeNumberDict.ElementAt(i).Key] = typeNumberDict.ElementAt(i).Value + 1;
                        }
                    }
                }
            }

            int totalNumVehicles = 0;

            foreach (var typeNumber in typeNumberDict)
            {
                totalNumVehicles += typeNumber.Value;
            }

            foreach (var typeNumber in typeNumberDict)
            {
                if (typeNumber.Value > 0)
                {
                    output.Append($"{typeNumber.Key}(s): {typeNumber.Value}\n");
                }
            }

            output.Append($"-----------------------------------------\nTotal: {totalNumVehicles} vehicles");
            return output.ToString();
        }

        public string ProduceAdvancedList(List<Type> typeList, string[] colourList, int minWheels, int maxWheels, string registrationNumber , double minWeight, double maxWeight)
        {
            string output = ""; // TODO stringbuilder
            //vehicles[0].

            var query = 
                from vehic in vehicles
                //where vehic != null
                where typeList.Contains(vehic.GetType())
                //where colourList.Contains(vehic.Colour)
                //where vehic.NumberOfWheels >= minWheels
                //where vehic.NumberOfWheels <= maxWheels
                //where vehic.RegistrationNumber == registrationNumber.ToUpper()
                //where vehic.Weight >= minWeight
                //where vehic.Weight <= maxWeight
                select vehic;
            i
            query =
                from vehic in query
                //where vehic != null
                //where typeList.Contains(vehic.GetType())
                where colourList.Contains(vehic.Colour)
                //where vehic.NumberOfWheels >= minWheels
                //where vehic.NumberOfWheels <= maxWheels
                //where vehic.RegistrationNumber == registrationNumber.ToUpper()
                //where vehic.Weight >= minWeight
                //where vehic.Weight <= maxWeight
                select vehic;



            foreach (Vehicle veh in query)
            {
                output += $"{veh}\n";
            }

            return output;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
 