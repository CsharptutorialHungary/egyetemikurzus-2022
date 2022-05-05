using ItemHandler;

namespace Commands
{
    internal class GetRings : IGetCommand
    {
        public bool Execute(params object[] args)
        {
            return new RingScraper().ScrapeAllItemsFromLink();
        }
    }
}
