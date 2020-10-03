using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Shop class, all the iteractions shoudl be done with it
    class Shop
    {
        public String Name { private set; get; }
        public String Location { private set; get; }
        public List<Consumer> Consumers { private set; get; }
        public List<Customer> Customers { private set; get; }
        public List<Stock> InventoryStocks { private set; get; }
        public List<Order> Orders { private set; get; }

        public Shop(String name, String location)
        {
            Name = name;
            Location = location;
            Consumers = new List<Consumer>();
            Customers = new List<Customer>();
            InventoryStocks = new List<Stock>();
            Orders = new List<Order>();
        }
        public void AddConsumer(Consumer consumer)
        {
            Consumers.Add(consumer);
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        // Add existing stock to shop
        public void AddStock(Stock stock)
        {
            InventoryStocks.Add(stock);
        }
    }
}
