namespace Inventory
{
    internal record class Armor
    {
        public string? Name { get; set; }

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

        public double Weight { get; set; }
        public double Durability { get; set; }

        public ArmorType Type { get; set; }
    }
}
