package BankSystem.Account;

import BankSystem.Client.Client;
import BankSystem.Client.VipClient;

public class BusinessAccount extends Account{
    public BusinessAccount(Client client) {
        super(client);
    }

    @Override
    public void Transfer(Account account, double money) {
        if (accountClient instanceof VipClient) {
            if (this.Withdraw(money)) {
                account.Deposit(money);
                eventLogger.Log("Transfer");
            }
        } else {
            if (this.Withdraw(money * 1.02)) {
                account.Deposit(money);
                eventLogger.Log("Transfer");
            }
        }
    }
}
