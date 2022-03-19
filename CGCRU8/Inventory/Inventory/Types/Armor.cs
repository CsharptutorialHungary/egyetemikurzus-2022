namespace Inventory.Types
{
    internal record class Armor
    {
        public double PhysicalDefense { get; set; }
        public double StrikeDefense { get; set; }
        public double SlashDefense { get; set; }
        public double ThrustDefense { get; set; }

        public double MagicDefense { get; set; }
        public double FireDefense { get; set; }
        public double LightningDefense { get; set; }
        public double DarkDefense { get; set; }
        
        public int BleedResistance { get; set; }
        public int PoisonResistance { get; set; }
        public int FrostResistance { get; set; }
        public int CurseResistance { get; set; }

        public double Poise { get; set; }

        public int Durability { get; set; }
        public double Weight { get; set; }
    }
}
