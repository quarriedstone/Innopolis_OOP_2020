using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Car
            Car car = new Car("Hyundai Coupe 2", "1500", "11.05.2002");
            Console.WriteLine("Car: ");
            car.Move();

            // Create Airplane
            Airplane airplane = new Airplane("Boieng-737", "10000", "23.07.1998");
            Console.WriteLine("Airplane: ");
            airplane.Move();

            // Create Ship
            Ship ship = new Ship("Titanic", "5231000", "31.05.1911");
            Console.WriteLine("Ship: ");
            ship.Move();

            Console.Read();
        }
    }
}
