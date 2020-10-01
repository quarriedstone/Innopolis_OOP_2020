using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Ship : Vehicle
    {
		public Ship(String name, String weight, String releaseDate)
		{
			this.name = name;
			this.weight = weight;
			this.releaseDate = releaseDate;
		}

		public override void Move()
		{
			Console.WriteLine("Move by swimming");
		}
	}
}
