namespace Inventory
{
    internal record class Item
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ItemType? Type { get; set; }
    }
}
