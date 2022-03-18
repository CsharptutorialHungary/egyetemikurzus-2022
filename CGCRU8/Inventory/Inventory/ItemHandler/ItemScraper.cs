using System;
using HtmlAgilityPack;
using Inventory;
using System.Configuration;

namespace ItemHandler
{
    public class ItemScraper
    {
        readonly private HttpClient _client;
        readonly private HtmlDocument _doc;
        readonly private string? _basePageLink;
        readonly private Dictionary<string, ItemType> _itemTypes;

        public ItemScraper()
        {
            _client = new HttpClient();
            _doc = new HtmlDocument();

            _basePageLink = ConfigurationManager.AppSettings["basePageLink"];

            _itemTypes = new Dictionary<string, ItemType>()
            {
                { "Key+Items",          new KeyItem()},
                { "Multiplayer+Items",  new MultiplayerItem()},
                { "Consumables",        new Consumable()},
                { "Tools",              new Tool()},
                { "Projectiles",        new Projectile()},
                { "Ammunition",         new Ammunition()},
                { "Souls",              new Soul()},
                { "Boss+Souls",         new BossSoul()},
                { "Ore",                new Ore()},
                { "Ashes",              new Ash()},
            };
        }

        public bool ScrapeAllItemsFromLink()
        {
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["allItemsFile"]))
                    return true;

                Logger.Log("Tárgyak létrehozása elkezdődött.");

                string url = (_basePageLink + "Items");
                string[] itemCategories = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Item> allItems = new List<Item>();

                foreach (string category in itemCategories)
                {
                    GetItemsFromCategory(allItems, category);
                    Logger.Log(_basePageLink + category + " oldal tárgyai elmentve.");
                }

                ItemSerializer.SaveItems(allItems);
            }
            catch (IOException ex)
            {
                Logger.Log("Hiba lépett fel a fájlművelet közben " + ex.Message);
                return false;
            }
            catch (HttpRequestException ex)
            {
                Logger.Log("Hiba lépett fel a weboldal feldolgozása közben " + ex.Message);
                return false;
            }

            Logger.Log("Tárgyak létrehozva!");
            return true;
        }

        private string[] GetSubPages(string url)
        {
            var html = _client.GetStringAsync(url);
            _doc.LoadHtml(html.Result);

            var subPages = _doc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("embedded-54eedd1d-83d0-4fda-9068-5c5447adce59"))
                .ToList()[0]
                .Descendants("div")
                .ToList()[0].InnerText;

            List<string> subPageNames = new List<string>();
            foreach (string subPage in subPages.Split("\n"))
                if (subPage.Trim().Length > 0)
                    subPageNames.Add(subPage.Trim().Replace(" ", "+"));

            return subPageNames.ToArray();
        }

        private void GetItemsFromCategory(List<Item> allItems, string category, string? basePageLink = null)
        {
            var html = _client.GetStringAsync((basePageLink == null ? _basePageLink : basePageLink) + category);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList();

            string[] headers = new string[]{"Name &amp; Icon", "Name", "Soul", "Bolts", "Arrows", "Great Arrows"};

            foreach (var item in table[0].Descendants("tr").ToList())
            {
                string[] itemProperties = item.InnerText.Split("\n");

                int startIndex = category == "Consumables" ? 2 : 1;

                if (headers.Contains(itemProperties[startIndex].Trim()))
                    continue;

                allItems.Add(new Item(
                    itemProperties[startIndex].Replace("&nbsp;", " ").Trim(),
                    category == "Boss+Souls" ? "-" : itemProperties[startIndex + 1].Replace("&nbsp;", " ").Trim(),
                    _itemTypes[category])
                );
            }
        }
    }
}
