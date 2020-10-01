using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Car : Vehicle
    {
		public Car(String name, String weight, String releaseDate)
		{
			this.name = name;
			this.weight = weight;
			this.releaseDate = releaseDate;
		}
	}
}
