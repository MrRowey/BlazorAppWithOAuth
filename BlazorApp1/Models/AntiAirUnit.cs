﻿namespace BlazorApp1.Models
{
    public class AntiAirUnit : UnitBase
    {
        public int DamagePerShot { get; set; }
        public double DamageRadius { get; set; }
        public int Range { get; set; }
        public int MuzzleVelocity { get; set; }
        public double Lifetime { get; set; }
        public double NumberOfShots { get; set; }
        public double RateOfFire { get; set; }
        public double ReloadTime { get; set; }

        // Cauculated Property
        public double FireCycle { get; set; }
        public int DamageTotal { get; set; }

        // Constructor


        public AntiAirUnit(string unitName, string unitID, int health, int massCost, int energyCost, int buildTime, int visionRange, int damagePerShot, double damageRadius, int range, int muzzleVelocity, double lifetime, double numberOfShots, double rateOfFire, double reloadTime) : base(unitName, unitID, health, massCost, energyCost, buildTime, visionRange)
        {
            DamagePerShot = damagePerShot;
            DamageRadius = damageRadius;
            Range = range;
            MuzzleVelocity = muzzleVelocity;
            Lifetime = lifetime;
            NumberOfShots = numberOfShots;
            RateOfFire = rateOfFire;
            ReloadTime = reloadTime;
            FireCycle = CaculateFireCycle();
            DamageTotal = TotalDamage();
        }

        // Cacualte Fire Cycle
        private double CaculateFireCycle()
        {
            return Math.Round((NumberOfShots / RateOfFire) + ReloadTime, 1);
        }

        // Calculate Total Damage
        public int TotalDamage()
        {
            return (int)(NumberOfShots * DamagePerShot);
        }

    }
}
