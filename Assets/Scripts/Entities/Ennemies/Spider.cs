public class Spider : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(15, 3f, 60);
        powerToUse = new SlowPower();
        AbsorbPower(powerToUse);
    }
}