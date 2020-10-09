package BankSystem.Account;

import BankSystem.Client.Client;
import BankSystem.Logger.EventLogger;
import BankSystem.Logger.ILogger;
import BankSystem.Logger.LogFactory;
/*
It might be 3 types of account business, credit and debit (regular)
 */

// "God" class of Account. It is better to separate it into several classes
public abstract class Account {

    protected ILogger eventLogger;

    public static String accountId;
    public static int lastId = 0;
    public static double balance = 0;

    public static Client accountClient;

    public Account(Client client){
        Account.lastId++;
        accountId = Integer.toString(Account.lastId);
        accountClient = client;
        eventLogger = LogFactory.CreateLogger();
    }


    // All the functions below should be override in child classes
    public void Deposit(double money){
        balance += money;
        this.eventLogger.Log("Deposit");
    }


    public boolean Withdraw(double money){
        if (balance >= money){
            balance -= money;
            this.eventLogger.Log("Withdraw");
            return true;
        }
        return false;
    }

    public void Transfer(Account account, double money) {
        if (this.Withdraw(money)) {
            account.Deposit(money);
            eventLogger.Log("Transfer");
        }
    }

}
