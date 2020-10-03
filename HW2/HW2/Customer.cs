using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public enum Gender { Male, Female, Undefined}

    class Customer
    {
        public String Name { private set;  get; }
        public int Age { private set; get; }
        public Gender Gender { set; get; }

        public Customer(String name, int age, Gender gender = Gender.Undefined)
        {
            // Check if name is empty
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Parameter Name is empty");
            }
            // Check if age is in bounds
            if (age > 190 || age < 0)
            {
                throw new ArgumentException($"Parameter age: {age} is bigger than 190 or less than 0");
            }
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"Customer information:\nName: {Name}, Age: {Age}, Gender: {Gender}\n";
        }
    }
}
