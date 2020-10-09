package BankSystem.Client;


import BankSystem.Account;
import BankSystem.Bank;

import java.util.ArrayList;
import java.util.List;

public abstract class Client {

    public String name;
    public String birthday;
    public String gender;

    // Bank should not be a field of Client.
    public BankSystem.Bank Bank;

    // I really don't like to have list of Accounts in Client, as Account could not exist without Bank.
    public List<Account> accounts = new ArrayList<>();

    // Bank should be responsible for connecting clients and accounts or even AccountBuilder class
    public Account CreateAccount(String type){
        Account account = new Account(this, type);
        accounts.add(account);

        return account;
    }


    // Single responsibility principle is violated.
    // Bank should be responsible for making client a VIP. It is better to make field instead
    /*
    This method makes another client a VIP client
     */
    public abstract void MakeClientVip(Client client);


}
