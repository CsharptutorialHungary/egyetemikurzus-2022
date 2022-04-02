using ItemHandler;

namespace Commands
{
    internal class GetWeapons : IGetCommand
    {
        public bool Execute()
        {
            return new WeaponScraper().ScrapeAllItemsFromLink();
        }
    }
}
