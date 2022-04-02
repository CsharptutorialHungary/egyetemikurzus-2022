using ItemHandler;

namespace Commands
{
    internal class GetRings : IGetCommand
    {
        public bool Execute()
        {
            return new RingScraper().ScrapeAllItemsFromLink();
        }
    }
}
