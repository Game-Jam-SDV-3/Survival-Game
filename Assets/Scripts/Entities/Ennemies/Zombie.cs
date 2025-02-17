public class Zombie : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new BitePower();
        AbsorbPower(powerToUse);
    }
}