public class Ghost : Monster
{
    new private void Start()
    {
        base.Start();

        Initialize(10, 4f, 50);
        powerToUse = new InvisibilityPower();
        AbsorbPower(powerToUse);
    }
}