using Inventory;
using System.Configuration;
using System.Globalization;
using Types;

namespace ItemHandler
{
    internal class RingScraper : Scraper<RingType, Ring>
    {

        public RingScraper() : base(itemTypes: new Dictionary<string, RingType>
                                                {
                                                    {"ring", new RingType()}
                                                }) 
        {}

        public override bool ScrapeAllItemsFromLink()
        {
            try
            {
#if RELEASE
                if (File.Exists(ConfigurationManager.AppSettings["allRingsFile"]))
                    return true;
#endif

                Logger.Log("Gyűrűk létrehozása elkezdődött.");

                List<Ring> allRings = new List<Ring>();
                GetItemsFromCategory(allRings, "Rings");

                Console.WriteLine("Gyűrű megszerezve: 1 / 1 (100%)");

                Serializer.SaveItems(allRings, ConfigurationManager.AppSettings["allRingsFile"]);
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

            Logger.Log("Gyűrűk létrehozva!");
            return true;
        }

        protected override string[] GetSubPages(string url) { return null;  }

        protected override void GetItemsFromCategory(List<Ring> allRings, string category, string? basePageLink = null)
        {
            var html = _client.GetStringAsync((basePageLink ?? _basePageLink) + category);
            _doc.LoadHtml(html.Result);

            var table = _doc.DocumentNode.Descendants("table").ToList()[0].Descendants("tbody").ToList();

            foreach (var ring in table[0].Descendants("tr").ToList())
            {
                if (ring.InnerText.Trim().StartsWith("Name"))
                    continue;

                string[] ringProperties = ring.InnerText.Replace("&nbsp;", "").Trim().Split("\n");

                allRings.Add(new Ring
                {
                    Name = ringProperties[0].Trim(),
                    Weight = double.Parse(ringProperties[1].Trim(), CultureInfo.InvariantCulture),
                    Effect = ringProperties[2].Trim(),
                    Type = _itemTypes["ring"],
                });
            }
        }
    }
}
