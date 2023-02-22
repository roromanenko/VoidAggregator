using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class ReleaseDto
    {
        public int Id { get; set; }
        public string ReleaseName { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public List<SongDto> Songs { get; set; } = new List<SongDto>();
        public Language Language { get; set; }
        public int LabelId { get; set; }
        public byte[] CoverImage { get; set; }
    }
}
