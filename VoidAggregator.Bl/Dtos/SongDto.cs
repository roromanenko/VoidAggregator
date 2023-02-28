using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class SongDto
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public List<AuthorSongDto> AuthorsSongs { get; set; } = new List<AuthorSongDto>();
        public LanguageDto Language { get; set; }
        public string SongText { get; set; }
        public bool IsExplicitContent { get; set; }
        public byte[] SongContent { get; set; }
    }
}
