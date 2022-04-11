public class StrengthWaterProp : IProp
{
    public void OnRemove(params object[] args)
    {
        MiningMachine.SpeedFactor/=2;
    }

    public void Use(params object[] args)
    {
        MiningMachine.SpeedFactor*=2;
    }
}