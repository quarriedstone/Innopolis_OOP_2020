package BankSystem;

import BankSystem.Client.Client;

import java.util.ArrayList;
import java.util.List;

public class Bank {

    public static String name;
    public int totalAmountOfMoney;

    public List<Client> Clients = new ArrayList<>();
    public List<Account> Accounts = new ArrayList<>();

    public void AddNewClient(Client client){
        Clients.add(client);
    }

    public void RemoveClient(Client client){
        Clients.remove(client);
    }

    // Single responsibility principle is violated.
    // It is better to make AccountBuilder to build accounts.
    public Account CreateAccount(Client client, String type){
        Account account = new Account(client, type);
        Accounts.add(account);

        return account;
    }

    // Single responsibility principle is violated.
    // The same logger should be created by LoggerBuilder, not he Bank
    public EventLogger CreateLogger(){
        return new EventLogger();
    }


}
