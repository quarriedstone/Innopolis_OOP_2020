import MenuItem.MenuItem;

// In diagram we have realization of interface, but private fields are not allowed in Java Interfaces,
// Thus we will use the Abstract class instead. Also, to make fields accessible in children, we will use ``protected``.
public abstract class IOrder {
    protected MenuItem menuItem;
    protected int amount;

    abstract float calculateCost();
    abstract MenuItem getMenuItem();
    abstract void setMenuItem(MenuItem menuItem);
    abstract int getAmount();
    abstract void setAmount(int amount);
}
