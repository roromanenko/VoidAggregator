using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class ReleaseDto
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
        public AuthorDto Author { get; set; }
		public string AuthorId { get; set; }
		public GenreDto Genre { get; set; }
        public List<SongDto> Songs { get; set; } = new List<SongDto>();
        public LanguageDto Language { get; set; }
		public byte[] CoverImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
