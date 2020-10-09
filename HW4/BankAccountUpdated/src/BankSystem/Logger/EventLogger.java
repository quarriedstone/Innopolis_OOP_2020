package BankSystem.Logger;

public class EventLogger implements ILogger{
    public void Log(String event){
        System.out.println(event);
    }
}
