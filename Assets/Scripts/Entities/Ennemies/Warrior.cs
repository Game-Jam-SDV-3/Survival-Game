public class Warrior : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(40, 1f, 200);
        powerToUse = new IncreaseDamagePower();
        AbsorbPower(powerToUse);
    }
}