using System;

namespace Library.Entities
{
    internal record Book
    {
        public Guid Id { get; set; }

        public string Title { get; init; }

        public string Author { get; init; }

        public int PublishYear { get; init; }        

        public DateTime ReceivedDate { get; init; }
    }
}
