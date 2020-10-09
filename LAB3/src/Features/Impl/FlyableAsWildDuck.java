package Features.Impl;

import Features.IFlyable;

public class FlyableAsWildDuck implements IFlyable {
    @Override
    public void Fly() {
        System.out.println("Fly as wild duck");
    }
}