using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Dataclass containing information about order
    class Order
    {
        public DateTime Date { set; get; }
        public Inventory Inventory { set; get; }
        public Consumer Consumer { set; get; }
        public Customer Customer { set; get; }
        public double Price { set; get; }
        public int Amount { set; get; }

        public Order(DateTime date, Inventory inventory, Consumer consumer, Customer customer, double price, int amount)
        {
            Date = date;
            Inventory = inventory;
            Consumer = consumer;
            Customer = customer;
            Price = price;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"Order information:\nDate: {Date}\n{Consumer}{Customer}{Inventory}Total price: {Price}\nTotal amount: {Amount}\n";
        }
    }
}
