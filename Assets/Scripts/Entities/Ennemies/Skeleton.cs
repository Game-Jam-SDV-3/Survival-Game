public class Skeleton : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(30, 3f, 100);
        powerToUse = new IncreaseResistancePower();
        AbsorbPower(powerToUse);
    }
}