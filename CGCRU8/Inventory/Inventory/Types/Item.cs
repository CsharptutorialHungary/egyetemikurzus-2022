namespace Inventory
{
    internal record class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public ItemType type { get; set; }

        public Item(string name, string description, ItemType type)
        {
            this.name = name;
            this.description = description;
            this.type = type;
        }
    }
}
