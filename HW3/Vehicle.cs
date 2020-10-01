using System;

// Abstract class Vehicle defines the properties and behaviour of all vehicles: Airplane, Ship and Car.
public abstract class Vehicle
{
	protected String name;
	protected String weight;
	protected String releaseDate;

	// Implements basic Move behaviour 
	public virtual void Move() { Console.WriteLine("Base kind of move"); }

	// Just setters and getters for field
	public String Name
	{
		get { return name; }
		set { name = value; }
	}
	public String Weight
	{
		get { return weight; }
		set { weight = value; }
	}
	public String ReleaseDate
	{
		get { return releaseDate; }
		set { releaseDate = value; }
	}
}
