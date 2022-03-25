using Inventory;
using System.Configuration;
using System.Globalization;

namespace ItemHandler
{
    internal class WeaponScraper : Scraper<WeaponType, Weapon>
    {

        public WeaponScraper() : base(itemTypes: new Dictionary<string, WeaponType>()
                                                {
                                                    { "Daggers",            new Dagger()},
                                                    { "Straight+Swords",    new StraightSword()},
                                                    { "Greatswords",        new Greatsword()},
                                                    { "Ultra+Greatswords",  new UltraGreatsword()},
                                                    { "Curved+Swords",      new CurvedSword()},
                                                    { "Katanas",            new Katana()},
                                                    { "Curved+Greatswords", new CurvedGreatsword()},
                                                    { "Piercing+Swords",    new PiercingSword()},
                                                    { "Axes",               new Axe()},
                                                    { "Greataxes",          new Greataxe()},
                                                    { "Hammers",            new Hammer()},
                                                    { "Great+Hammers",      new GreatHammer()},
                                                    { "Fist+&+Claws",       new FistAndClaw()},
                                                    { "Spears+&+Pikes",     new SpearAndSpike()},
                                                    { "Halberds",           new Halberd()},
                                                    { "Reapers",            new Reaper()},
                                                    { "Whips",              new Whip()},
                                                    { "Bows",               new Bow()},
                                                    { "Greatbows",          new Greatbow()},
                                                    { "Crossbows",          new Crossbow()},
                                                    { "Staves",             new Stave()},
                                                    { "Flames",             new Flame()},
                                                    { "Talismans",          new Talisman()},
                                                    { "Sacred+Chimes",      new SacredChime()},
                                                })
        {}

        public override bool ScrapeAllItemsFromLink()
        {
            try
            {
#if RELEASE
                if (File.Exists(ConfigurationManager.AppSettings["allWeaponsFile"]))
                    return true;
#endif

                Logger.Log("Fegyverek létrehozása elkezdődött.");

                string url = (_basePageLink + "Weapons");
                string[] weaponCategories = GetSubPages(url);
                Logger.Log("Aloldalak linkje megszerezve.");

                List<Weapon> allWeapons = new List<Weapon>();

                for (int i = 0; i < weaponCategories.Length; i++)
                {
                    GetItemsFromCategory(allWeapons, weaponCategories[i]);

                    Console.WriteLine($"Fegyver megszerezve: {i + 1} / {weaponCategories.Length} ({(int)((i + 1) / (double)weaponCategories.Length * 100)}%)");

                    Logger.Log(_basePageLink + weaponCategories[i] + " oldal fegyverei elmentve.");
                }

                Serializer<Weapon>.SaveItems(allWeapons, ConfigurationManager.AppSettings["allWeaponsFile"]);
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

            Logger.Log("Fegyverek létrehozva!");
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
                .Descendants("div")
                .ToList();

            List<string> subPageNames = new List<string>();
            foreach (string subPage in (subPages[0].InnerText + subPages[16].InnerText).Split("\n"))
                if (subPage.Trim().Length > 0 && subPage.Trim() != "&nbsp;")
                    subPageNames.Add(subPage.Trim().Replace(" ", "+").Replace("&amp;", "&"));

            return subPageNames.ToArray();
        }

        protected override void GetItemsFromCategory(List<Weapon> allWeapons, string category, string? basePageLink = null)
        {
            var html = _client.GetStringAsync((basePageLink ?? _basePageLink) + category);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList()[0].Descendants("tbody").ToList();

            foreach (var weapon in table[0].Descendants("tr").ToList())
            {
                string[] weaponProperties = weapon.InnerText.Replace("&nbsp;", "").Trim().Split("\n");

                string name = weaponProperties[0].Trim();
                int attack = Convert.ToInt32(weaponProperties[1].Trim().Split(" ")[0]);

                int index = new[] { "Flames", "Whips"}.Contains(category) ? 9 : 8;

                string[] strength = weaponProperties[index++].Trim().Split(" ");
                int strRequirement = strength[0] == "-" ? 0 : Convert.ToInt32(strength[0]);
                char strScale = Convert.ToChar(strength[1]);

                string[] dexterity = weaponProperties[index++].Trim().Split(" ");
                int dexRequirement = dexterity[0] == "-" ? 0 : Convert.ToInt32(dexterity[0]);
                char dexScale = Convert.ToChar(dexterity[1]);

                string[] intelligence = weaponProperties[index++].Trim().Split(" ");
                int intRequirement = intelligence[0] == "-" ? 0 : Convert.ToInt32(strength[0]);
                char intScale = intelligence.Length == 1 ? '-' : Convert.ToChar(intelligence[1]);

                string[] faith = weaponProperties[index++].Trim().Split(" ");
                int fthRequirement = faith[0] == "-" ? 0 : Convert.ToInt32(strength[0]);
                char fthScale = faith.Length == 1 ? '-' : Convert.ToChar(intelligence[1]);

                index = category == "Staves" ? 14 : new[] { "Flames", "Bows", "Greatbows", "Whips" }.Contains(category) ? 13 : 12;

                string[] durabilityAndWeight = weaponProperties[index].Trim().Split(" ");
                _ = int.TryParse(durabilityAndWeight[0], out int durability);
                double weight = category == "Staves" ? double.Parse(weaponProperties[index - 1].Trim(), CultureInfo.InvariantCulture) :  double.Parse(durabilityAndWeight[1], CultureInfo.InvariantCulture);

                allWeapons.Add(new Weapon
                {
                    Name = name,
                    Attack = attack,
                    
                    StrengthRequirement = strRequirement,
                    StrenthScaling = strScale,
                    
                    DexterityRequirement = dexRequirement,
                    DexterityScaling = dexScale,
                    
                    IntelligenceRequirement = intRequirement,
                    IntelligenceScaling = intScale,
                    
                    FaithRequirement = fthRequirement,
                    FaithScaling = fthScale,

                    Durability = durability,
                    Weight = weight,

                    Type = _itemTypes[category]
                });
            }
        }
    }
}
