namespace Types
{
    internal record class Ring : Item
    {
        public override string? Name { get; set; }
        public double Weight { get; set; }
        public string? Effect { get; set; }

        public RingType Type { get; set; }
    }
}
