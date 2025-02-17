public class Warrior : Monster
{
    new private void Start()
    {
        base.Start();

        Initialize(40, 1f, 200);
        powerToUse = new IncreaseDamagePower();
        AbsorbPower(powerToUse);
    }
}