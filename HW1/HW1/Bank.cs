using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    public enum ClientType { Regular, GoldenCardHolder, VIP };
    public enum AccountType { Debit, Credit, Saving, Business };

    class Bank
    {
        public String Name { set; get; }
        private List<BankClient> Clients { set; get; }
        private Dictionary<BankClient, List<Guid>> AccountsIDs { set; get; }
        private Dictionary<Guid, Account> IDsToAccount { set; get; }

        // Basic constructor for bank. 
        public Bank(String name) 
        {
            Name = name;
            Clients = new List<BankClient>();
            AccountsIDs = new Dictionary<BankClient, List<Guid>>();
            IDsToAccount = new Dictionary<Guid, Account>();
        }

        // Adds new Client to client list by creating corresponding BankClient.
        public void AddNewClient(Client client, ClientType type = ClientType.Regular) 
        {
            Clients.Add(new BankClient(client, type));
            Console.WriteLine($"{Name}: Created new Banking client with name {client.Name}");
        }

        // Creates account for client with given account type.
        public Guid CreateAccountForClient(Client client, AccountType type, DateTime date)
        {
            BankClient bankClient = GetBankClientByClient(client);
            // Check if bank client already exists in dictionary
            if (!AccountsIDs.ContainsKey(bankClient))
            {
                AccountsIDs[bankClient] = new List<Guid>();
            }
            Guid guid = CreateUnicID();
            switch (type)
            {
                case AccountType.Debit:
                    AccountsIDs[bankClient].Add(guid);
                    IDsToAccount[guid] = new DebitAccount(bankClient, guid);
                    Console.WriteLine($"{Name}: Created `Debit` Account for client with name {client.Name}");
                    break;
                case AccountType.Credit:
                    AccountsIDs[bankClient].Add(guid);
                    IDsToAccount[guid] = new CreditAccount(bankClient, guid);
                    Console.WriteLine($"{Name}: Created `Credit` Account for client with name {client.Name}");
                    break;
                case AccountType.Saving:
                    AccountsIDs[bankClient].Add(guid);
                    IDsToAccount[guid] = new SavingAccount(bankClient, date, guid);
                    Console.WriteLine($"{Name}: Created `Saving` Account client with name {client.Name}");
                    break;
                case AccountType.Business:
                    AccountsIDs[bankClient].Add(guid);
                    IDsToAccount[guid] = new BusinessAccount(bankClient, guid);
                    Console.WriteLine($"{Name}: Created `Business` Account client with name {client.Name}");
                    break;
            }
            bankClient.AccountNumber++;
            // Return newly created accountID
            return guid;
        }

        // Lists all the client information for current bank
        public void ListAllClients() 
        {
            Console.WriteLine($"Client information for bank: {Name}");
            foreach (BankClient client in Clients) 
            {
                Console.WriteLine(client.ToString());
            }
        }

        // Lists all information about all accounts for current bank
        public void ListAllAccounts()
        {
            Console.WriteLine($"Accounts information for bank: {Name}");
            foreach (List<Guid> accounts in AccountsIDs.Values) 
            {
                foreach (Guid ID in accounts)
                {
                    Console.WriteLine(IDsToAccount[ID].ToString());
                }
            }
        }

        // Lists accounts of particular client for current bank
        public void ListClientAccounts(Client client)
        {
            Console.WriteLine($"Accounts information for bank: {Name}");

            BankClient bankClient = GetBankClientByClient(client);
            Console.WriteLine(bankClient.ToString());
            if (AccountsIDs.ContainsKey(bankClient))
            {
                foreach (Guid ID in AccountsIDs[bankClient])
                {
                    Console.WriteLine(IDsToAccount[ID].ToString());
                }

            }
            
        }
        
        // Wrapping around account methods. The bank should perform all operations. The user should use bank as service.
        public void Deposit(Guid accountID, double moneyAmount)
        {
            if (IDsToAccount.ContainsKey(accountID))
            {
                IDsToAccount[accountID].Deposit(moneyAmount);
                Console.WriteLine($"{Name}: Succesfuly deposit {moneyAmount} to {accountID}\n");
            }
            else
            {
                Console.WriteLine($"{Name}: Failed to deposit money: No account with ID {accountID} found\n");
            }
                
        }

        public void Withdraw(Guid accountID, double moneyAmount)
        {
            if (IDsToAccount.ContainsKey(accountID))
            {
                switch (IDsToAccount[accountID].Withdraw(moneyAmount))
                {
                    case Flags.Success:
                        Console.WriteLine($"{Name}: Succesfuly withdrawed {moneyAmount} from {accountID}\n");
                        break;
                    case Flags.NotEnoughMoney:
                        Console.WriteLine($"{Name}: Failed to withdraw {moneyAmount} from {accountID}. Not enough money\n");
                        break;
                    case Flags.TooEarlyDate:
                        Console.WriteLine($"{Name}: Failed to withdraw {moneyAmount} from {accountID}. Saving account date did not pass.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{Name}: Failed to deposit money: No account with ID {accountID} found\n");
            }
        }

        public void Transfer(Guid sourceAccountID, Guid destAccountID, double moneyAmount)
        {
            if (IDsToAccount.ContainsKey(sourceAccountID)) 
            {
                if (IDsToAccount.ContainsKey(destAccountID))
                {
                    switch (IDsToAccount[sourceAccountID].Transfer(moneyAmount, IDsToAccount[destAccountID]))
                    {
                        case Flags.Success:
                            Console.WriteLine($"{Name}: Succesfuly transfered money from {sourceAccountID} to {destAccountID}\n");
                            break;
                        case Flags.NotEnoughMoney:
                            Console.WriteLine($"{Name}: Failed to transfer {moneyAmount} from {sourceAccountID} to {destAccountID}. Not enough money\n");
                            break;
                        case Flags.TooEarlyDate:
                            Console.WriteLine($"{Name}: Failed to transfer {moneyAmount} from {sourceAccountID} to {destAccountID}. Saving account date did not pass.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"{Name}: Failed to deposit money: No account with ID {destAccountID} found\n");
                }
            }
            else
            {
                Console.WriteLine($"{Name}: Failed to deposit money: No account with ID {sourceAccountID} found\n");
            }
        }

        // Outputs all the operations dony in account
        public void ListOperations(Guid accountID)
        {
            if (IDsToAccount.ContainsKey(accountID))
            {
                Console.WriteLine(string.Join("\n", IDsToAccount[accountID].Operations));
            }
            else
            {
                Console.WriteLine($"{Name}: Failed to load operations: No account with ID {accountID} found\n");
            }
        }
        // Finds Banking client by Client
        private BankClient GetBankClientByClient(Client client) 
                {
                    return Clients.Find(delegate (BankClient curr) { return curr.Equals(client); });
                }

        private Guid CreateUnicID()
        {
            return Guid.NewGuid();
        }
    }
}
