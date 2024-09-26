namespace BlazorApp1.Services
{
    public class CalculationService
    {
        public double PercentageChange( int currentValue, int previousValue)
        {
            if (previousValue == 0) return 0; // avoid division by zero
            return Math.Round((currentValue - previousValue) / (double)previousValue * 100, 2);
        }

        public double TotalFireCycle(int shotsNumber, double rateofFire, double reloadTime)
        {
            return Math.Round(shotsNumber / rateofFire + reloadTime, 1);
        }

        public int TotalDamage(int shotsNumber, int damagePerShot)
        {
            return shotsNumber * damagePerShot;
        }

    }
}
