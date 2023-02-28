using VoidAggregator.Dal.Entities.Enums;
using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Dal.Entities
{
    public class Release
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Language Language { get; set; }
        public string CoverImagePath { get; set; }
    }
}
