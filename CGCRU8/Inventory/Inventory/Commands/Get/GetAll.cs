using ItemHandler;

namespace Commands
{
    internal class GetAll : IGetCommand
    {
        public bool Execute(params object[] args)
        {
            return new CollectibleScraper().ScrapeAllItemsFromLink() &&
                new WeaponScraper().ScrapeAllItemsFromLink() &&
                new ArmorScraper().ScrapeAllItemsFromLink() &&
                new RingScraper().ScrapeAllItemsFromLink();
        }
    }
}
