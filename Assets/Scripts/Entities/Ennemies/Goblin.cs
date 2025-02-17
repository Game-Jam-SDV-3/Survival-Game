public class Goblin : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(20, 6f, 60);
        powerToUse = new IncreaseSpeedPower();
        AbsorbPower(powerToUse);
    }
}