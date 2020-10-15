import MenuItem.MenuItem;
import MenuItem.Sugar;
import MenuItem.Cappuccino;

public class Main {
    public static void main(String[] args) {
        MenuItem cappuccino = new Cappuccino();
        MenuItem sugar = new Sugar();

        MenuOrder menu = new MenuOrder(cappuccino, 1, new MenuOrder(sugar, 1));
    }
}
