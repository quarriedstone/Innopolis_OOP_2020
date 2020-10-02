using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public enum Gender { Male, Female, Undefined};
    class Client : IEquatable<Client>
    {
        public String Name { private set; get; }
        public DateTime BirthDate { private set; get; }
        // You may change gender, if you want :)
        public Gender Gender { set; get; }

        public Client(String name, DateTime birthDate, Gender gender = Gender.Undefined)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
        }

        // Create custom equality method for client instancies. If all parameters are the same, then client is the same
        public bool Equals(Client other)
        {
            return BirthDate == other.BirthDate && Name == other.Name && Gender == other.Gender;
        }

        public override string ToString()
        {
            return $"Client information:\nName: {Name}\nBirth date: {BirthDate:dd/MM/yyyy}\nGender: {Gender}\n";
        }
    }
}
