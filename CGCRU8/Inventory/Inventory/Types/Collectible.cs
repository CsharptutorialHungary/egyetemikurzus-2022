namespace Inventory
{
    internal record class Collectible
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CollectibleType? Type { get; set; }
    }
}
