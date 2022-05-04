namespace Types
{
    internal record class Armor : Item
    {
        public override string Name { get; set; }

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

        public override ItemType Type { get; set; }

        public override string ToString()
        {
            return 
                $"{Name}\n\n" +
                $"PhysicalDefense: {PhysicalDefense}\n" +
                $"StrikeDefense: {StrikeDefense}\n" +
                $"SlashDefense: {SlashDefense}\n" +
                $"ThrustDefense: {ThrustDefense}\n\n" +
                $"MagicDefense: {MagicDefense}\n" +
                $"FireDefense: {FireDefense}\n" +
                $"LightningDefense: {LightningDefense}\n" +
                $"DarkDefense: {DarkDefense}\n\n" +
                $"BleedResistance: {BleedResistance}\n" +
                $"PoisonResistance: {PoisonResistance}\n" +
                $"FrostResistance: {FrostResistance}\n" +
                $"CurseResistance: {CurseResistance}\n\n" +
                $"Poise: {Poise}\n\n" +
                $"Weight: {Weight}\n" +
                $"Durability: {Durability}\n\n" +
                $"Type: {Type.Name}\n" +
                $"Type description: {Type.Description}";
        }
    }
}
