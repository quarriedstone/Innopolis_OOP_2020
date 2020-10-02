using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    // As client could exist outside of bank, we need some bank specific structure to hold information about client type. 
    // We, of course may have used ``struct`` or ``Map`` to hold such information, but let's be as OOP as possible
    class BankClient : IEquatable<Client>
    {
        // MoneyAmount and number of accounts are tightened to the particular bank
        public double MoneyAmount { set; get; }
        public double AccountNumber { set; get; }
        public ClientType Type { set; get; }
        public Client Client { private set; get; }

        // Constructor for Bank client.
        public BankClient(Client client, ClientType type = ClientType.Regular)
        {
            Type = type;
            Client = client;
            MoneyAmount = 0;
            AccountNumber = 0;
        }

        // As Client has ``equals`` method realised, let's use it to check if BankClient belongs to Client 
        public bool Equals(Client other)
        {
            return Client.Equals(other);
        }

        public override string ToString()
        {
            return Client.ToString() + $"Client type: {Type}\nMoney amount: {MoneyAmount}\nNumber of accounts: {AccountNumber}\n";
        }
    }
}
