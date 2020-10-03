using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Consumer is customer but with more rights, he could create Orders
    class Consumer : Customer
    {
        public Consumer(String name, int age, Gender gender = Gender.Undefined) : base(name, age, gender) { }
        public Order CreateOrder(DateTime date, Inventory inventory, Customer customer, int amount, Stock stock)
        {
            // Check if there is enough inventory
            if (stock.GetInventoryAmount(inventory) >= amount)
            {
                // If category is Clothes, than we don't need to check the expiration date
                if (inventory.Category == Category.Clothes) 
                {
                    return new Order(date, inventory, this, customer, inventory.Price * amount, amount);
                }
                // For Food and Pharmacy, we also need to check the expiration date
                if (inventory.ExpirationDate >= date)
                {
                    return new Order(date, inventory, this, customer, inventory.Price * amount, amount);
                }
                else
                {
                    throw new Exception("Could not create order: Expiration date is violated");
                }
            }
            throw new Exception("Could not create order: Not enough inventory amount");
        }
        public override string ToString()
        {
            return $"Consumer information:\nName: {Name}, Age: {Age}, Gender: {Gender}\n";
        }
    }
}
