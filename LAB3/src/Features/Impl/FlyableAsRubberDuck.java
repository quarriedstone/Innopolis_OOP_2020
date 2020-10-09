package Features.Impl;

import Features.IFlyable;

public class FlyableAsRubberDuck implements IFlyable {
    @Override
    public void Fly() {
        System.out.println("Cannot fly");
    }
}
