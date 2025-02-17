public class Witch : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new HealPower();
        AbsorbPower(powerToUse);
    }
}