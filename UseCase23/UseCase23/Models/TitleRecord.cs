using CsvHelper.Configuration;

namespace UseCase23.Models
{
    public record class TitleRecord
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Certification { get; set; }
        public int Runtime { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string Country { get; set; }
        public int Seasons { get; set; }
    }

    public class TitleMap : ClassMap<TitleRecord>
    {
        public TitleMap()
        {
            Map(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Description);
            Map(x => x.ReleaseYear);
            Map(x => x.Certification);
            Map(x => x.Runtime);
            Map(x => x.Country);
            Map(x => x.Seasons);
            Map(x => x.Genres).Name("Genres").Convert(args =>
            {
                var genres = args.Value.Genres;
                return string.Join(", ", genres);
            });
        }
    }
}
