using Inventory;
using System.Configuration;
using Types;

namespace ItemHandler
{
    internal class CollectibleScraper : Scraper<CollectibleType, Collectible>
    {
        public CollectibleScraper() : base(itemTypes : new Dictionary<string, CollectibleType>()
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
                                                        })
        {}

        public override bool ScrapeAllItemsFromLink()
        {
            try
            {
#if RELEASE
                if (File.Exists(ConfigurationManager.AppSettings["allItemsFile"]))
                    return true;
#endif

                Logger.Log("Tárgyak létrehozása elkezdődött.");

                string url = (_basePageLink + "Items");
                string[] itemCategories = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Collectible> allItems = new List<Collectible>();

                for (int i = 0; i < itemCategories.Length; i++)
                {
                    GetItemsFromCategory(allItems, itemCategories[i]);

                    Console.WriteLine($"Tárgy megszerezve: {i + 1} / {itemCategories.Length} ({(int)((i + 1) / (double)itemCategories.Length * 100)}%)");

                    Logger.Log(_basePageLink + itemCategories[i] + " oldal tárgyai elmentve.");
                }

                Serializer.SaveItems(allItems, ConfigurationManager.AppSettings["allItemsFile"]);
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

        protected override string[] GetSubPages(string url)
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

        protected override void GetItemsFromCategory(List<Collectible> allItems, string category, string? basePageLink = null)
        {
            var html = _client.GetStringAsync((basePageLink ?? _basePageLink) + category);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList()[0].Descendants("tbody").ToList();

            string[] headers = new string[]{"Name &amp; Icon", "Name", "Icon", "Soul", "Bolts", "Arrows", "Great Arrows"};

            foreach (var item in table[0].Descendants("tr").ToList())
            {
                string[] itemProperties = item.InnerText.Replace("&nbsp;", "").Trim().Split("\n");

                if (headers.Contains(itemProperties[0].Trim()))
                    continue;

                allItems.Add(new Collectible
                {
                    Name = itemProperties[0].Trim(),
                    Description = category == "Boss+Souls" ? "-" : itemProperties[1].Trim(),
                    Type = _itemTypes[category]
                });
            }
        }
    }
}
