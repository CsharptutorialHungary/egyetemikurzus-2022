using HtmlAgilityPack;
using System.Configuration;

namespace ItemHandler
{
    internal abstract class Scraper<ItemType, DataType>
    {
        protected readonly HttpClient _client;
        protected readonly HtmlDocument _doc;
        protected readonly string? _basePageLink;
        protected readonly Dictionary<string, ItemType> _itemTypes;

        protected Scraper(Dictionary<string, ItemType> itemTypes)
        {
            _client = new HttpClient();
            _doc = new HtmlDocument();

            _basePageLink = ConfigurationManager.AppSettings["basePageLink"];
            _itemTypes = itemTypes;
        }

        public abstract bool ScrapeAllItemsFromLink();

        protected abstract string[] GetSubPages(string url);

        protected abstract void GetItemsFromCategory(List<DataType> allItems, string category, string? basePageLink = null);
    }
}
