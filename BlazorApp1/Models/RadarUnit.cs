namespace BlazorApp1.Models
{
    public class ShieldUnit : UnitBase
    {
        public int ShieldHealth { get; set; }
        public int ShieldRegenRate { get; set; }
        public int ShieldSize { get; set; }
        public int ShieldRechargeTime { get; set; }
        
        public int BuildRate { get; set; }
        public int EnergyDrain { get; set; }


        public ShieldUnit(string unitName, string unitID, int health, int massCost, int energyCost, int buildTime, int visionRange, int shieldHealth, int shieldRegenRate, int shieldSize, int shieldRechargeTime, int buildRate, int energyDrain) : base(unitName, unitID, health, massCost, energyCost, buildTime, visionRange)
        {
            ShieldHealth = shieldHealth;
            ShieldRegenRate = shieldRegenRate;
            ShieldSize = shieldSize;
            ShieldRechargeTime = shieldRechargeTime;
            BuildRate = buildRate;
            EnergyDrain = energyDrain;
        }
    }
}
