package BankSystem.Client;


public abstract class Client {

    public String name;
    public String birthday;
    public String gender;

    public Client(String name, String birthday, String gender){
        this.name = name;
        this.birthday = birthday;
        this.gender = gender;
    }
}
