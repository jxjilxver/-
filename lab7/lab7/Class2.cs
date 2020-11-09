using System;
using System.Collections.Generic;
using System.Text;

namespace lab7
{
    static class Agency//контейнер
    {
        public static List<Vehicle> AllVehicles = new List<Vehicle>();
        public static List<Vehicle> vehicles { get { return AllVehicles; } set { } }

        public static void Add(Vehicle veh)
        {
            AllVehicles.Add(veh);
            Console.WriteLine("В список добавлено новое ТС");
        }

        public static Vehicle Remove(Vehicle veh)
        {
            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle == veh)
                {
                    AllVehicles.Remove(veh);
                    Console.WriteLine("Элемент удалён");
                    return veh;
                }
            }
            Console.WriteLine("Такого элемента в списке нет");
            return null;
        }

        public static void ShowList()
        {
            Console.WriteLine("Полный список ТС:");
            foreach (Vehicle veh in AllVehicles)
            {
                Console.WriteLine("type: " + veh.GetType());
                veh.ToString();
                Console.WriteLine("-------------------------");
            }
        }
    }
    public class CarCopmarer : IComparer<Vehicle>
    {
        public int Compare(Vehicle car1, Vehicle car2)
        {
            if (((Car)car1).Expenditure > ((Car)car2).Expenditure) return 1;
            else if (((Car)car1).Expenditure < ((Car)car2).Expenditure) return -1;
            else return 0;
        }
    }
    public partial class Controller
    {
        public static List<Vehicle> SortByExpenditure(List<Vehicle> vehicles)
        {
            List<Vehicle> ListOfCars = new List<Vehicle>();
            foreach (Vehicle car in vehicles)
            {
                if (Convert.ToString(car.GetType()) == "lab6.Car")
                    ListOfCars.Add(car);
            }
            ListOfCars.Sort(0, ListOfCars.Count, new CarCopmarer());
            return ListOfCars;
        }
    }
}
