using VoidAggregator.Api.Models.Enums;

namespace VoidAggregator.Api.Models
{
    public class Release
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
		public Author Author { get; set; }
		public Genre Genre { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();
        public Language Language { get; set; }
        public Label Label { get; set; }
        public byte[] CoverImage { get; set; }
}
}
