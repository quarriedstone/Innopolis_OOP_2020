using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Food : Inventory
    {
        public Food(String name, DateTime createDate, double price, DateTime expirationDate) : base(name, createDate, price)
        {
            ExpirationDate = expirationDate;
            Category = Category.Food;
        }
    }
}
