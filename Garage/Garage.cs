using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        #region Properties **************************************************************

        private T[] vehicles;

        public object Current => throw new NotImplementedException();
        #endregion


        #region Constructors ************************************************************
        public Garage(int numberOfParkingSpaces)
        {
            vehicles = new T[numberOfParkingSpaces];
        }
        #endregion


        #region Methods *****************************************************************

        public void ParkVehicle(T vehicle)
        {
            int firstEmptyArraySpace = Array.IndexOf(vehicles, null);

            if (firstEmptyArraySpace >= 0)
            {
                foreach (T veh in vehicles)
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
                vehicles[firstEmptyArraySpace] = vehicle;
            }
            else
            {
                throw new Exception("Sorry. No free parkingspaces!");
            }
        }

        
        /// <summary>
        /// All the types of vehicles parked in the garage
        /// </summary>
        /// <returns>Types</returns>
        //public IEnumerable<Type> GetVehicleTypes()
        //{
        //    Type parentType = typeof(Vehicle);
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    Type[] types = assembly.GetTypes();

        //    IEnumerable<Type> subclasses = types.Where(t => t.BaseType == parentType);

        //    return subclasses;
        //}


        public bool UnparkVehicle(T vehicle)
        {
            bool unparkingSuccess = false;

            for (int i = 0; i < vehicles.Length - 1; i++)
            {
                if (vehicles[i].Equals(vehicle))
                {
                    vehicles[i] = default;
                    unparkingSuccess = true;
                }
            }
            return unparkingSuccess;
        }

        

        public string[] ListParkedVehiclesColours()
        {
            HashSet<string> colourSet = new HashSet<string>();

            foreach (T vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    colourSet.Add(vehicle.Colour);
                }
            }

            string[] colourArr = colourSet.ToArray();

            return colourArr;
        }


        public string ProduceAdvancedList(List<Type> typeList, string[] colourList, int minWheels, int maxWheels, string registrationNumber , double minWeight, double maxWeight)
        {
            StringBuilder output = new StringBuilder();

            IEnumerable<T> query = 
                from vehic in vehicles
                where !vehic.Equals(default)
                select vehic;

            if (typeList.Count > 0)
            {
                query =
                    from vehic in query
                    where typeList.Contains(vehic.GetType())
                    select vehic;
            }

            if (colourList[0] != "*")
            {
                query =
                    from vehic in query
                    where colourList.Contains(vehic.Colour)
                    select vehic;
            }

            query =
                from vehic in query
                where vehic.NumberOfWheels >= minWheels
                where vehic.NumberOfWheels <= maxWheels
                select vehic;

            if (registrationNumber != "*")
            {
                query =
                    from vehic in query
                    where vehic.RegistrationNumber == registrationNumber.ToUpper()
                    select vehic;
            }

            query =
                    from vehic in query
                    where vehic.Weight >= minWeight
                    where vehic.Weight <= maxWeight
                    select vehic;

            foreach (T veh in query)
            {
                output.Append($"{veh}\n");
            }

            return output.ToString();
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle != null) 
                    yield return vehicle;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
 