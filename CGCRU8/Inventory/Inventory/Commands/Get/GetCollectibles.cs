using ItemHandler;

namespace Commands
{
    internal class GetCollectibles : IGetCommand
    {
        public bool Execute()
        {
            return new CollectibleScraper().ScrapeAllItemsFromLink();
        }
    }
}
