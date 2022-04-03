namespace Types
{
    internal record class Weapon : Item
    {
        public override string Name { get; set; }
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

        public override ItemType Type { get; set; }

        public override string ToString()
        {
            return 
                $"{Name}\n\n" +
                $"Attack: {Attack}\n\n" +
                $"Strength requirement: {StrengthRequirement}\n" +
                $"Strength scailing: {StrenthScaling}\n\n" +
                $"Dexterity requirement: {DexterityRequirement}\n" +
                $"Dexterity scaling: {DexterityScaling}\n\n" +
                $"Intelligence requirement: {IntelligenceRequirement}\n" +
                $"Intelligence scaling: {IntelligenceScaling}\n\n" +
                $"Faith requirement: {FaithRequirement}\n" +
                $"Faith scaling: {FaithScaling}\n\n" +
                $"Durability: {Durability}\n" +
                $"Weight: {Weight}\n\n" +
                $"Type: {Type.Name}\n" +
                $"Type description: {Type.Description}";
        }
    }
}
