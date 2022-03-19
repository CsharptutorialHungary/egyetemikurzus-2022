using HtmlAgilityPack;
using Inventory;
using System.Configuration;
using System.Globalization;

namespace ItemHandler
{
    internal class ArmorScraper
    {
        readonly private HttpClient _client;
        readonly private HtmlDocument _doc;
        readonly private string? _basePageLink;
        readonly private Dictionary<string, ArmorType> _armorTypes;

        public ArmorScraper()
        {
            _client = new HttpClient();
            _doc = new HtmlDocument();

            _basePageLink = ConfigurationManager.AppSettings["basePageLink"];

            _armorTypes = new Dictionary<string, ArmorType>()
            {
                { "Helms",          new Helmet()},
                { "Chest+Armor",    new Chest()},
                { "Gauntlets",      new Gauntlet()},
                { "Leggings",       new Legging()},
            };
        }

        public bool ScrapeAllArmorsFromLink()
        {
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["allArmorsFile"]))
                    return true;

                Logger.Log("Páncélok létrehozása elkezdődött.");

                string url = (_basePageLink + "Armor");
                string[] armorCategories = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Armor> allArmors = new List<Armor>();

                foreach (string category in armorCategories)
                {
                    GetArmorsFromCategory(allArmors, category);
                    Logger.Log(_basePageLink + category + " oldal tárgyai elmentve.");
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

        private string[] GetSubPages(string url)
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

        private void GetArmorsFromCategory(List<Armor> allArmors, string category, string? basePageLink = null)
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

                    Type = _armorTypes[category],
                });
            }
        }
    }
}
