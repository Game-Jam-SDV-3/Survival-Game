public class Skeleton : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new IncreaseResistancePower();
        AbsorbPower(powerToUse);
    }
}