public class Witch : Monster
{
    new private void Start()
    {
        base.Start();
        
        Initialize(20, 2f, 80);
        powerToUse = new HealPower();
        AbsorbPower(powerToUse);
    }
}