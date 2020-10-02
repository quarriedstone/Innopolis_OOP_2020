using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Client. Client can exist outside of Bank scope
            Client client1 = new Client("Herman", new DateTime(1998, 7, 23), Gender.Male);
            Client client2 = new Client("Elina", new DateTime(1998, 09, 18), Gender.Female);

            // Create Bank
            Bank sber_bank = new Bank("Sberbank");
            Bank tinkoff_bank = new Bank("Tinkoff");

            // Add Client1 to Sberbank: Debit and Business
            sber_bank.AddNewClient(client1);
            Guid client1Debit = sber_bank.CreateAccountForClient(client1, AccountType.Debit, DateTime.Now);
            Guid client1Business = sber_bank.CreateAccountForClient(client1, AccountType.Business, DateTime.Now);
            
            // Add Client2 to Sberbank: Credit and Saving
            sber_bank.AddNewClient(client2);
            Guid client2Credit = sber_bank.CreateAccountForClient(client2, AccountType.Credit, DateTime.Now);
            Guid client2Saving = sber_bank.CreateAccountForClient(client2, AccountType.Saving, new DateTime(2100, 12, 12));

            // Deposit 5000 on Client1 Debit and Business account and check the total money amount before and after. 
            // The total amount should be 10000
            Console.WriteLine("################################################");
            sber_bank.ListClientAccounts(client1);
            sber_bank.Deposit(client1Debit, 5000);
            sber_bank.Deposit(client1Business, 5000);
            sber_bank.ListClientAccounts(client1);

            // For Client2, lets withdraw some money from Credit card. It should be -5000
            Console.WriteLine("################################################");
            sber_bank.ListClientAccounts(client2);
            sber_bank.Withdraw(client2Credit, 5000);
            sber_bank.ListClientAccounts(client2);
            Console.WriteLine("################################################");

            // For Client2, let's try to withdraw money from Saving account. It should print error
            sber_bank.ListClientAccounts(client2);
            sber_bank.Withdraw(client2Saving, 5000);
            sber_bank.ListClientAccounts(client2);
            Console.WriteLine("################################################");

            // Now, let's transfer some money from Business card to Debit card of Client1. 
            // As Client1 is Regular, the 2 percent charge will be taken. 
            sber_bank.ListClientAccounts(client1);
            sber_bank.Transfer(client1Business, client1Debit, 4000);
            sber_bank.ListClientAccounts(client1);
            Console.WriteLine("################################################");

            // Now let's performa some basic operations on bank
            sber_bank.ListAllClients();
            Console.WriteLine("################################################");
            sber_bank.ListAllAccounts();
            Console.WriteLine("################################################");

            // The last one, let's print all operations performed on Client1 Business account
            sber_bank.ListOperations(client1Business);

            Console.ReadKey();
        }
    }
}
