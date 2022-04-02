using ItemHandler;

namespace Commands
{
    internal class GetArmors : IGetCommand
    {
        public bool Execute()
        {
            return new ArmorScraper().ScrapeAllItemsFromLink();
        }
    }
}
