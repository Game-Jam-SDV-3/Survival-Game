public class Zombie : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(10, 2f, 70);
        powerToUse = new BitePower();
        AbsorbPower(powerToUse);
    }
}