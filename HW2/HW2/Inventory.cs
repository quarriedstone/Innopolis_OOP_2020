using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Abstract class representing Inventory. Is used as base class for different categories of products
    abstract class Inventory : IEquatable<Inventory>
    {
        public Category Category { set; get; } 
        public String Name { set; get; }
        public DateTime CreateDate { set; get; }
        public double Price { set; get; }
        public DateTime ExpirationDate { protected set; get; }

        // Base constructor for Inventory
        public Inventory(String name, DateTime createDate, double price)
        {
            Name = name;
            CreateDate = createDate;
            Price = price;
        }

        // Custom equality function. If all parameters are the same, than inventory is the same
        public bool Equals(Inventory other)
        {
            return other.Category == Category && other.Name == Name && other.CreateDate == CreateDate && other.Price == Price;
        }

        public override string ToString()
        {
            return $"Inventory information:\nName: {Name}, Category: {Category}, Create date: {CreateDate}, Price of 1 inventory: {Price}\n";
        }
    }
}
