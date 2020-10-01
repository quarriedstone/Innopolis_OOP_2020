using System;

namespace HW3
{
	class Program
	{
		static void Main(string[] args)
		{
			Airplane airplane = new Airplane("Boeing-737", "10000", "23.07.98");
			airplane.Move();
		}
	}
}
