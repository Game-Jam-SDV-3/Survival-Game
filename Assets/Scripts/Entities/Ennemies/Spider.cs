public class Spider : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new SlowPower();
        AbsorbPower(powerToUse);
    }
}