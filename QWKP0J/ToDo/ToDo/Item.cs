namespace ToDo
{
    internal class Item
    {
        public string Task { get; set; }
        public bool IsComplete { get; set; }
        public Item(string task)
        {
            Task = task;
            IsComplete = false;
        }
    }
}
