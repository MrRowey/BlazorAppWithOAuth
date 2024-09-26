namespace BlazorApp1.Services
{
    public class CalculationService
    {
        public double PercentageChange( double currentValue, double previousValue)
        {
            if (previousValue == 0) return 0; // avoid division by zero
            return Math.Round((currentValue - previousValue) / previousValue * 100, 2);
        }

        public double CaculateFireCycle(int NumberOfShots, double RateOfFire, double ReloadTime)
        {
            return Math.Round((NumberOfShots / RateOfFire) + ReloadTime, 1);
        }

        public int TotalDamage(int shotsNumber, int damagePerShot)
        {
            return shotsNumber * damagePerShot;
        }

    }
}
