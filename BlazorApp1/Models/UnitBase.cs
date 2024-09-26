namespace BlazorApp1.Models
{
    public class UnitBase
    {
        // Unit Description
        public string UnitName { get; set; }
        public string UnitID { get; set; }
        
        // Unit Cost Stats
        public int Health { get; set; }
        public int MassCost { get; set; }
        public int EnergyCost { get; set; }
        public int BuildTime { get; set; }

        // Intel
        public int VisionRange { get; set; }


        // Constructor
        public UnitBase(string unitName, string unitID, int health, int massCost, int energyCost, int buildTime, int visionRange)
        {
            UnitName = unitName;
            UnitID = unitID;
            Health = health;
            MassCost = massCost;
            EnergyCost = energyCost;
            BuildTime = buildTime;
            VisionRange = visionRange;
        }
    }
}
