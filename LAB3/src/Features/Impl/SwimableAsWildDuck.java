package Features.Impl;

import Features.ISwimable;

public class SwimableAsWildDuck implements ISwimable {
    @Override
    public void swim() {
        System.out.println("Swim as wild duck");
    }
}