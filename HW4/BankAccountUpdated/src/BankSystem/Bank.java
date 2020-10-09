package BankSystem;

import BankSystem.Account.Account;
import BankSystem.Account.AccountFactory;
import BankSystem.Account.AccountType;
import BankSystem.Client.Client;
import BankSystem.Client.VipClient;

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

    public void MakeClientVip(Client client) {
        if (client instanceof VipClient) {
            return;
        }
        Client vipClient = new VipClient(client.name, client.birthday, client.gender);
        int index = this.Clients.indexOf(client);
        this.Clients.set(index, vipClient);
    }

    public Account CreateAccount(Client client, AccountType type){
        Account account = AccountFactory.createAccount(client, type);
        Accounts.add(account);

        return account;
    }
}
