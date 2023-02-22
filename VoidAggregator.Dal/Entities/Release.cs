using VoidAggregator.Dal.Entities.Enums;

namespace VoidAggregator.Dal.Entities
{
    public class Release
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Language Language { get; set; }
        public int LabelId { get; set; }
        public string CoverImagePath { get; set; }
    }
}
