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

        private const string basePageLink = "https://darksouls3.wiki.fextralife.com/";

        readonly private Dictionary<string, ItemType> _itemTypes;

        public ItemScraper()
        {
            _client = new HttpClient();
            _doc = new HtmlDocument();

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

                string url = (basePageLink + "Items");
                string[] subPages = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Item> allItems = new List<Item>();

                foreach (string subPage in subPages)
                {
                    GetItemsFromCategory(allItems, basePageLink + subPage, subPage);
                    Logger.Log(basePageLink + subPage + " oldal tárgyai elmentve.");
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

        private void GetItemsFromCategory(List<Item> allItems, string url, string category)
        {
            var html = _client.GetStringAsync(url);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList();

            foreach (var item in table[0].Descendants("tr").ToList())
            {
                string[] itemProperties = item.InnerText.Split("\n");

                int startIndex = category == "Consumables" ? 2 : 1; 

                if (itemProperties[startIndex].Trim().StartsWith("Name"))
                    continue;

                allItems.Add(new Item(itemProperties[startIndex].Trim(),
                    itemProperties[startIndex + 1].Replace("&nbsp;", " ").Trim(),
                    _itemTypes[category])
                );
            }
        }
    }
}
