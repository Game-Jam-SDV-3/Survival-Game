public class Goblin : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new IncreaseSpeedPower();
        AbsorbPower(powerToUse);
    }
}