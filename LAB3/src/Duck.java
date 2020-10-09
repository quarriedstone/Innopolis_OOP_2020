import Features.IFlyable;
import Features.ISwimable;

public abstract class Duck {

    public abstract String getType();

    private IFlyable flyable;
    private ISwimable swimable;

    public void setFlyable(IFlyable flyable) {
        this.flyable = flyable;
    }

    public void setSwimable(ISwimable swimable) {
        this.swimable = swimable;
    }

    public IFlyable getFlyable() {
        return flyable;
    }
    public ISwimable getSwimable() {
        return swimable;
    }
}
