﻿using System;

namespace HW3
{
	public class Airplane : Vehicle
	{
		public Airplane(String name, String weight, String releaseDate)
		{
			this.name = name;
			this.weight = weight;
			this.releaseDate = releaseDate;
		}
		
		// Override behaviour of Airplane
		public override void Move()
		{
			Console.WriteLine("Move by flying");
		}
	}
}