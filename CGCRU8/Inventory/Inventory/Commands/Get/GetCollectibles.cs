using ItemHandler;

namespace Commands
{
    internal class GetCollectibles : IGetCommand
    {
        public bool Execute(params object[] args)
        {
            return new CollectibleScraper().ScrapeAllItemsFromLink();
        }
    }
}
