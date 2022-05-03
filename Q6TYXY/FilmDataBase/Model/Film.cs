using System.Xml.Serialization;
namespace FilmDataBase.Model
{
    [Serializable()]
    public class Film
    {
        [XmlElementAttribute("Title")]
        public string Title { get; set; }
        [XmlElementAttribute("Year")]
        public int Year { get; set; }
        [XmlElementAttribute("Genre")]
        public string Genre { get; set; }
        [XmlElementAttribute("Director")]
        public string Director { get; set; }
        [XmlElementAttribute("Studio")]
        public string Studio { get; set; }
        [XmlElementAttribute("Rate")]
        public double Rate { get; set; }
    }
}
