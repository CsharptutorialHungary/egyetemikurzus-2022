using ItemHandler;

namespace Commands
{
    internal class GetWeapons : IGetCommand
    {
        public bool Execute(params object[] args)
        {
            return new WeaponScraper().ScrapeAllItemsFromLink();
        }
    }
}
