using Inventory;
using System.Configuration;
using System.Globalization;

namespace ItemHandler
{
    internal class ArmorScraper : Scraper<ArmorType, Armor>
    {
        public ArmorScraper() : base(itemTypes: new Dictionary<string, ArmorType>()
                                                {
                                                    { "Helms",          new Helmet()},
                                                    { "Chest+Armor",    new Chest()},
                                                    { "Gauntlets",      new Gauntlet()},
                                                    { "Leggings",       new Legging()},
                                                })
        {}


        public override bool ScrapeAllItemsFromLink()
        {
            try
            {
#if RELEASE
                if (File.Exists(ConfigurationManager.AppSettings["allArmorsFile"]))
                    return true;
#endif

                Logger.Log("Páncélok létrehozása elkezdődött.");

                string url = (_basePageLink + "Armor");
                string[] armorCategories = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Armor> allArmors = new List<Armor>();

                for (int i = 0; i < armorCategories.Length; i++)
                {
                    GetItemsFromCategory(allArmors, armorCategories[i]);
                    
                    Console.WriteLine($"Páncél megszerezve: {i + 1} / {armorCategories.Length} ({(int)((i + 1) / (double)armorCategories.Length * 100)}%)");

                    Logger.Log(_basePageLink + armorCategories[i] + " oldal tárgyai elmentve.");
                }

                Serializer<Armor>.SaveItems(allArmors, ConfigurationManager.AppSettings["allArmorsFile"]);
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

            Logger.Log("Páncélok létrehozva!");
            return true;
        }

        protected override string[] GetSubPages(string url)
        {
            var html = _client.GetStringAsync(url);
            _doc.LoadHtml(html.Result);

            var subPages = _doc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("wiki-content-block"))
                .ToList()[0]
                .Descendants("a")
                .ToList();

            List<string> subPageNames = new List<string>();
            for (int i = 2; i <= 5; i++)
                subPageNames.Add(subPages[i].Attributes["href"].Value.Replace("/", ""));

            return subPageNames.ToArray();
        }

        protected override void GetItemsFromCategory(List<Armor> allArmors, string category, string? basePageLink = null)
        {
            var html = _client.GetStringAsync((basePageLink ?? _basePageLink) + category);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList()[0].Descendants("tbody").ToList();

            foreach (var armor in table[0].Descendants("tr").ToList())
            {
                string[] armorProperties = armor.InnerText.Replace("&nbsp;", "").Trim().Split("\n");

                allArmors.Add(new Armor
                {
                    Name = armorProperties[0].Trim(),

                    PhysicalDefense = double.Parse(armorProperties[1].Trim(), CultureInfo.InvariantCulture),
                    StrikeDefense = double.Parse(armorProperties[2].Trim(), CultureInfo.InvariantCulture),
                    SlashDefense = double.Parse(armorProperties[3].Trim(), CultureInfo.InvariantCulture),
                    ThrustDefense = double.Parse(armorProperties[4].Trim(), CultureInfo.InvariantCulture),

                    MagicDefense = double.Parse(armorProperties[5].Trim(), CultureInfo.InvariantCulture),
                    FireDefense = double.Parse(armorProperties[6].Trim(), CultureInfo.InvariantCulture),
                    LightningDefense = double.Parse(armorProperties[7].Trim(), CultureInfo.InvariantCulture),
                    DarkDefense = double.Parse(armorProperties[8].Trim(), CultureInfo.InvariantCulture),

                    BleedResistance = Convert.ToInt32(armorProperties[9].Trim()),
                    PoisonResistance = Convert.ToInt32(armorProperties[10].Trim()),
                    FrostResistance = Convert.ToInt32(armorProperties[11].Trim()),
                    CurseResistance = Convert.ToInt32(armorProperties[12].Trim()),

                    Poise = double.Parse(armorProperties[13].Trim(), CultureInfo.InvariantCulture),

                    Weight = double.Parse(armorProperties[14].Trim(), CultureInfo.InvariantCulture),
                    Durability = armorProperties[15].Contains("?") ? -1 : double.Parse(armorProperties[15].Trim(), CultureInfo.InvariantCulture),

                    Type = _itemTypes[category],
                });
            }
        }
    }
}
