package BankSystem.Logger;

public class LogFactory {
    // We might have different types of logger, thus some Factory method could be applied
    public static ILogger CreateLogger(){
        return new EventLogger();
    }
}
