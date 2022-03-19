namespace Inventory
{
    internal record class Weapon
    {
        public string? Name { get; set; }
        public int Attack { get; set; }

        public int StrengthRequirement { get; set; }
        public char StrenthScaling { get; set; }

        public int DexterityRequirement { get; set; }
        public char DexterityScaling { get; set; }

        public int IntelligenceRequirement { get; set; }
        public char IntelligenceScaling { get; set; }

        public int FaithRequirement { get; set; }
        public char FaithScaling { get; set; }

        public int Durability { get; set; }
        public double Weight { get; set; }

        public WeaponType? Type { get; set; }
    }
}
