public class Spider : Monster
{
    new private void Start()
    {
        base.Start();
        
        Initialize(15, 3f, 60);
        powerToUse = new SlowPower();
        AbsorbPower(powerToUse);
    }
}