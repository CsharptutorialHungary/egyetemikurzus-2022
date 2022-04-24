namespace Types
{
    internal abstract record class Item
    {
        public virtual string Name { get; set; }
        public virtual ItemType Type { get; set; }
    }
}
