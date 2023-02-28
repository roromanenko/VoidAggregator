using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class ReleaseDto
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
        public AuthorDto Author { get; set; }
        public Genre Genre { get; set; }
        public List<SongDto> Songs { get; set; } = new List<SongDto>();
        public Language Language { get; set; }
        public LabelDto Label { get; set; }
        public byte[] CoverImage { get; set; }
    }
}
