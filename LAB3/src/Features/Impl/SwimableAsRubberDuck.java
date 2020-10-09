package Features.Impl;

import Features.ISwimable;

public class SwimableAsRubberDuck implements ISwimable {
    @Override
    public void swim() {
        System.out.println("Swim as rubber duck");
    }
}
