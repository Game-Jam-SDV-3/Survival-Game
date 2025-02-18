public class Goblin : Monster
{
    new private void Start()
    {
        base.Start();
        
        Initialize(20, 6f, 60);
        powerToUse = new IncreaseSpeedPower();
        AbsorbPower(powerToUse);
    }
}