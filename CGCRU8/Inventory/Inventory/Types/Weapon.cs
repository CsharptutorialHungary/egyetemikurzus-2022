namespace Inventory
{
    internal record class Weapon
    {
        public string Name { get; private set; }
        public int Attack { get; private set; }

        public int StrengthRequirement { get; private set; }
        public char StrenthScaling { get; private set; }

        public int DexterityRequirement { get; private set; }
        public char DexterityScaling { get; private set; }

        public int IntelligenceRequirement { get; private set; }
        public char IntelligenceScaling { get; private set; }

        public int FateRequirement { get; private set; }
        public char FateScaling { get; private set; }

        public int Durability { get; private set; }
        public int Weight { get; private set; }

        public WeaponType Type { get; private set; }

        public Weapon(string name, int attack, int strengthRequirement, char strenthScaling, int dexterityRequirement, char dexterityScaling, int intelligenceRequirement, char intelligenceScaling, int fateRequirement, char fateScaling, int durability, int weight, WeaponType type)
        {
            Name = name;
            Attack = attack;
            StrengthRequirement = strengthRequirement;
            StrenthScaling = strenthScaling;
            DexterityRequirement = dexterityRequirement;
            DexterityScaling = dexterityScaling;
            IntelligenceRequirement = intelligenceRequirement;
            IntelligenceScaling = intelligenceScaling;
            FateRequirement = fateRequirement;
            FateScaling = fateScaling;
            Durability = durability;
            Weight = weight;
            Type = type;
        }
    }
}
