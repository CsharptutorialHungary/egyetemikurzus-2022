using HtmlAgilityPack;
using Inventory;
using System.Configuration;
using System.Globalization;

namespace ItemHandler
{
    internal class RingScraper
    {
        readonly private HttpClient _client;
        readonly private HtmlDocument _doc;
        readonly private string? _basePageLink;

        public RingScraper()
        {
            _client = new HttpClient();
            _doc = new HtmlDocument();

            _basePageLink = ConfigurationManager.AppSettings["basePageLink"];
        }

        public bool ScrapeAllRingsFromLink()
        {
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["allArmorsFile"]))
                    return true;

                Logger.Log("Gyűrűk létrehozása elkezdődött.");

                List<Ring> allRings = new List<Ring>();
                GetRingsFromPage(allRings, "Rings");

                Serializer<Ring>.SaveItems(allRings, ConfigurationManager.AppSettings["allRingsFile"]);
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

        private void GetRingsFromPage(List<Ring> allRings, string category, string? basePageLink = null)
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
                });
            }
        }
    }
}
