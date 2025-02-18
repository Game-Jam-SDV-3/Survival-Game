public class Skeleton : Monster
{
    new private void Start()
    {
        base.Start();

        Initialize(30, 3f, 100);
        powerToUse = new FireballPower();
        AbsorbPower(powerToUse);
    }
}