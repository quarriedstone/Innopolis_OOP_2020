package BankSystem.Client;

public class VipClient extends Client {
    @Override
    public void MakeClientVip(Client client) {

        if (client instanceof VipClient){
            return;
        }
        // The code below makes Client a VIP in some Bank. It is better to move out the logic outside.
        Client vipClient = new VipClient();
        vipClient.name = client.name;
        vipClient.birthday = client.birthday;
        vipClient.accounts = client.accounts;

        int index = this.Bank.Clients.indexOf(client);
        this.Bank.Clients.set(index,vipClient);
    }
}
