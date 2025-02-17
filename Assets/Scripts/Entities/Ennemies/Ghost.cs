public class Ghost : Monster
{
    public IPower powerToUse;

    private void Start()
    {
        powerToUse = new InvisibilityPower();
        AbsorbPower(powerToUse);
    }
}