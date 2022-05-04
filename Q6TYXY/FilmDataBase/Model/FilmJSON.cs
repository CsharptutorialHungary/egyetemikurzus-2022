using Newtonsoft.Json;

namespace FilmDataBase.Model
{
    internal class FilmJSON
    {
        [JsonProperty("Title")]
        public string Title { get;  }
        [JsonProperty("Year")]
        public string Year { get; }
        [JsonProperty("Rated")]
        public string Rated { get; }
        [JsonProperty("Released")]
        public string Released { get; }
        [JsonProperty("Runtime")]
        public string Runtime { get; }
        [JsonProperty("Genre")]
        public string Genre { get; }
        [JsonProperty("Director")]
        public string Director { get; }
        [JsonProperty("Writer")]
        public string Writer { get; }
        [JsonProperty("Actors")]
        public string Actors { get; }

        public FilmJSON(string title, string year, string rated, string released, string runtime, string genre, string director, string writer, string actors)
        { 
        
            Title = title;
            Year = year;
            Rated = rated;
            Released = released;
            Runtime = runtime;
            Director = director;
            Writer = writer;
            Actors = actors;

        }

    }
}
