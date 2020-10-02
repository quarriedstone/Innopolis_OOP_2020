using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    // Just flags as return values from methods
    enum Flags { Success, NotEnoughMoney, TooEarlyDate}

    abstract class Account
    {
        // Money amount on Account. Default value is 0. Also, we don't want to change amount of money through setters. 
        public double MoneyAmount { get; protected set; }
        public BankClient Client { get; protected set; }
        // List of all performed operations on this account
        public List<string> Operations { get; set; }
        // Unique ID given by bank to account
        public Guid AccountId { private set; get; }

        // Default constructors for derived classes. One creates account with specified money amount and client holder, 
        // another just creates empty account.
        public Account(BankClient client, double moneyAmount, Guid accountId) 
        { 
            MoneyAmount = moneyAmount;
            Client = client;
            Client.MoneyAmount += moneyAmount;
            AccountId = accountId;
            Operations = new List<string>();
        }
        public Account(BankClient client, Guid accountId) 
        { 
            MoneyAmount = 0;
            Client = client;
            AccountId = accountId;
            Operations = new List<string>();
        }
        // Method to withdraw money from account. Basic behaviour - we may not withdraw money if we have not enough money.
        public virtual Flags Withdraw(double moneyAmount) { 
            if (this.MoneyAmount > moneyAmount)
            {
                this.MoneyAmount -= moneyAmount;
                
                // Change global money amount
                Client.MoneyAmount -= moneyAmount;

                // Log operation
                Operations.Add($"Withdrawal succeeded: {moneyAmount}");
                return Flags.Success;
            }
            Operations.Add($"Withdrawal failed: {moneyAmount}");
            return Flags.NotEnoughMoney;
        }

        // Method to add money to account.
        public void Deposit(double moneyAmount) 
        { 
            this.MoneyAmount += moneyAmount;
            Client.MoneyAmount += moneyAmount;

            Operations.Add($"Deposit succeeded: {moneyAmount}");
        }

        // Method to transfer money from one account to another. Coeff shows the fee bank takes fro transaction
        public virtual Flags Transfer(double moneyAmount, Account account, double coeff = 0) 
        {
            Operations.Add($"Transfer started from {AccountId}: {moneyAmount} to {account.AccountId}");
            // Check if we may withdraw the money from current account
            if (Withdraw(moneyAmount / (1 - coeff)) == Flags.Success)
            {
                // If we can withdraw, than add money to another account
                account.Deposit(moneyAmount);
                Operations.Add($"Transfer ended from {AccountId}: {moneyAmount} to {account.AccountId}");
                return Flags.Success;
            }
            return Flags.NotEnoughMoney;
        }

        public override string ToString()
        {
            return $"Account ID: {AccountId}\nMoney amount on account: {MoneyAmount}\n";
        }
    }
}
