namespace Types
{
    internal record class Ring : Item
    {
        public override string Name { get; set; }
        public double Weight { get; set; }
        public string? Effect { get; set; }

        public override ItemType Type { get; set; }

        public override string ToString()
        {
            return 
                $"{Name}\n\n" +
                $"{Effect}" + 
                $"Weight: {Weight}\n\n" +
                $"Ring description: {Type.Description}";
        }
    }
}
