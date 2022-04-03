namespace Types
{
    internal record class Collectible : Item
    {
        public override string? Name { get; set; }
        public string? Description { get; set; }
        public CollectibleType? Type { get; set; }
    }
}
