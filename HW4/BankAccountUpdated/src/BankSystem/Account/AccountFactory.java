package BankSystem.Account;

import BankSystem.Client.Client;

public class AccountFactory {
    public static Account createAccount(Client client, AccountType type){
        switch (type) {
            case Business:
                return new BusinessAccount(client);
            case Credit:
                return new CreditAccount(client);
            case Debit:
                return new DebitAccount(client);
        }
        return null;
    }
}
