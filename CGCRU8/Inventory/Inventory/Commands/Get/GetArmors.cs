using ItemHandler;

namespace Commands
{
    internal class GetArmors : IGetCommand
    {
        public bool Execute(params object[] args)
        {
            return new ArmorScraper().ScrapeAllItemsFromLink();
        }
    }
}
