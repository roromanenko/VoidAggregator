using VoidAggregator.Bl.Dtos.Enums;

namespace VoidAggregator.Bl.Dtos
{
    public class AuthorSongDto
    {
        public AuthorDto Author { get; set; }
		public string AuthorId { get; set; }
		public SongDto Song { get; set; }
		public int SongId { get; set; }
		public AuthorRoleDto AuthorRole { get; set; }
    }
}
