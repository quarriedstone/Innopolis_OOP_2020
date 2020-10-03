using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public enum Category{ Clothes, Food, Pharmacy }
    class Stock
    {
        class InventoryAmount
        {
            // Data class for holding tuples. As tuples are immutable, it is better to make class
            public InventoryAmount(Inventory inventory, int amount)
            {
                Inventory = inventory;
                Amount = amount;
            }

            public Inventory Inventory { set; get; }
            public int Amount { set; get; }


        }
        public Category Category { set; get; }
        private List<InventoryAmount> InventoryAmountList { set; get; }
        public List<Consumer> Consumers { private set; get; }
        public List<Customer> Customers { private set; get; }

        public Stock(Category category)
        {
            Category = category;
            InventoryAmountList = new List<InventoryAmount>();
            Consumers = new List<Consumer>();
            Customers = new List<Customer>();
        }

        public void AddConsumer(Consumer consumer)
        {
            Consumers.Add(consumer);
        }
        
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        // Adds inventory to Stock with given amount. Default amount 1
        public void AddInventory(Inventory inventory, int amount = 1)
        {
            InventoryAmountList.Add(new InventoryAmount(inventory, amount));
        }

        // Removes inventory from stock
        public void RemoveInventory(Inventory inventory)
        {
            InventoryAmount curr = InventoryAmountList.Find(x => x.Inventory.Equals(inventory));
            if (curr != null)
            {
                InventoryAmountList.Remove(curr);
            }
            else
            {
                throw new Exception("No inventory found");
            }
        }

        // Removes inventory with given amount, if given amount is bigger than current amount - throw exception
        public void RemoveInventory(Inventory inventory, int amount)
        {
            InventoryAmount curr = InventoryAmountList.Find(x => x.Inventory.Equals(inventory));
            if (curr.Amount > amount)
            {
                curr.Amount -= amount;
            }
            else
            {
                throw new Exception($"Not enough amount in stock");
            }
        }

        // Get amount of given inventory in stock. If the `inventory` is not found, return 0.
        public int GetInventoryAmount(Inventory inventory)
        {
            InventoryAmount curr = InventoryAmountList.Find(x => x.Inventory.Equals(inventory));
            return curr != null ? curr.Amount : 0;
        }
    }
}
