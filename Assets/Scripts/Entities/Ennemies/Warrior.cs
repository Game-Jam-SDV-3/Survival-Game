public class Warrior : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new IncreaseDamagePower();
        AbsorbPower(powerToUse);
    }
}