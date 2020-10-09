package BankSystem.Account;

import BankSystem.Client.Client;

public class CreditAccount extends Account{
    public CreditAccount(Client client) {
        super(client);
    }
    @Override
    public boolean Withdraw(double money) {
        balance -= money;
        this.eventLogger.Log("Withdraw");
        return true;
    }
}
