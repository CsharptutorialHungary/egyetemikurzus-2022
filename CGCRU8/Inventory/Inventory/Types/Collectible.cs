namespace Types
{
    internal record class Collectible : Item
    {
        public override string? Name { get; set; }
        public string? Description { get; set; }
        public CollectibleType? Type { get; set; }

        public override string ToString()
        {
            return 
                $"{Name}\n\n" +
                $"${Description}\n\n" +
                $"Type: {Type.Name}\n" +
                $"Type description: {Type.Description}";
        }
    }
}
