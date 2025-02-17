public class Ghost : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        Initialize(10, 4f, 50);
        powerToUse = new InvisibilityPower();
        AbsorbPower(powerToUse);
    }
}