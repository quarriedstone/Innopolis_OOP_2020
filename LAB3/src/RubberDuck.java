import Features.IFlyable;
import Features.ISwimable;

public class RubberDuck extends Duck
{
    private final String type="Rubber Duck";

    @Override
    public String getType() {
        return this.type;
    }
}
