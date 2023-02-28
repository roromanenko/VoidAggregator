using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class AuthorSongDto
    {
        public AuthorDto Author { get; set; }
        public SongDto Song { get; set; }
        public AuthorRole AuthorRole { get; set; }
    }
}
