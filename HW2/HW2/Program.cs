using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's create customer and consumer
            Customer customer1 = new Customer("Herman", 22, Gender.Male);
            Consumer consumer1 = new Consumer("Elina", 22, Gender.Female);

            // Now let's create the shop
            Shop shop = new Shop("Bahetle", "Innopolis");

            // We need to create different stocks for shop and add them to stock list
            Stock stockPharmacy = new Stock(Category.Pharmacy);
            Stock stockClothes = new Stock(Category.Clothes);
            Stock stockFood = new Stock(Category.Food);
            shop.AddStock(stockPharmacy);
            shop.AddStock(stockFood);
            shop.AddStock(stockClothes);

            // Add some customers and consumers to shop
            shop.AddConsumer(consumer1);
            shop.AddCustomer(customer1);

            // Let's create some Inventory
            Pharmacy pharmacy = new Pharmacy("Ibuprofen", new DateTime(2020, 10, 01), 100, new DateTime(2021, 10, 01));
            Clothes clothes = new Clothes("Massimo Dutti Shirt", new DateTime(2020, 10, 01), 1500, Size.L);
            Food food = new Food("Echpochmak", new DateTime(2020, 10, 01), 25, new DateTime(2020, 10, 03));

            // Add inventory to stock.
            stockPharmacy.AddInventory(pharmacy, 10);
            stockFood.AddInventory(food, 20);
            stockClothes.AddInventory(clothes, 5);

            // Now let's create order for Food. The date of order will be after expiration date
            try
            {
                consumer1.CreateOrder(new DateTime(2020, 10, 04), food, customer1, 1, stockFood);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Now let's create order for clothes, it should not have problems
            Console.WriteLine(consumer1.CreateOrder(new DateTime(2020, 10, 04), clothes, customer1, 2, stockClothes));

            // And finally let's buy more echpochmak than we have in Stock!
            try
            {
                consumer1.CreateOrder(new DateTime(2020, 10, 02), food, customer1, 30, stockFood);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
