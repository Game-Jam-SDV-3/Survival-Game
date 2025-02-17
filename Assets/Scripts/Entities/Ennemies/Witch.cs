public class Witch : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(20, 2f, 80);
        powerToUse = new HealPower();
        AbsorbPower(powerToUse);
    }
}