using System;
using System.Collections.Generic;
using System.Text;

namespace lab6
{
    public partial class Controller
    {
        public static int FullPrice(List<Vehicle> vehicles)
        {
            int sum=0;
            foreach(Vehicle veh in vehicles)
            {
                sum += veh.Price;
            }
            return sum;
        }
        public static void SpeedInRange(List<Vehicle> vehicles)
        {
            List<Vehicle> veh = new List<Vehicle>();
            foreach(Vehicle vehicle in vehicles)
            {
                if (Convert.ToString(vehicle.GetType()) == "lab6.Car")
                    veh.Add(vehicle);
            }
            Console.WriteLine("Машины со скоростью больше 200 км/ч и меньше 230 км/ч");
            foreach(Car vehicle in veh)
            {
                if(vehicle.Speed > 200 && vehicle.Speed < 230)
                {
                    vehicle.ToString();
                }
            }
        }
    }
}
