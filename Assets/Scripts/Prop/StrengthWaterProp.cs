public class StrengthWaterProp : IProp
{
    public void OnRemove(params object[] args)
    {
        MiningMachine.SpeedHalf();
    }

    public void Use(params object[] args)
    {
        MiningMachine.SpeedDouble();
    }
}