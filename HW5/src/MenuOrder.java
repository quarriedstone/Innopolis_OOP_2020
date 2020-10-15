import MenuItem.MenuItem;

import java.awt.*;

public class MenuOrder extends IOrder{
    private MenuOrder order;

    public MenuOrder(MenuItem menuItem, int amount, MenuOrder menuOrder){
        this.order = menuOrder;
        this.amount = amount;
        this.menuItem = menuItem;
    }

    public MenuOrder(MenuItem menuItem, int amount){
        this.order = null;
        this.amount = amount;
        this.menuItem = menuItem;
    }

    @Override
    float calculateCost() {
        float cost = this.getAmount() * this.getMenuItem().getPrice();

        if (this.getOrder() != null){
            cost += this.getOrder().calculateCost();
        }

        return cost;
    }

    @Override
    MenuItem getMenuItem() {
        return this.menuItem;
    }

    @Override
    void setMenuItem(MenuItem menuItem) {
        this.menuItem = menuItem;
    }

    @Override
    int getAmount() {
        return this.amount;
    }

    @Override
    void setAmount(int amount) {
        this.amount = amount;
    }

    public MenuOrder getOrder() {
        return order;
    }

    public void setOrder(MenuOrder order) {
        this.order = order;
    }
}
