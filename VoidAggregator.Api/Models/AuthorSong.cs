using VoidAggregator.Api.Models.Enums;
using VoidAggregator.Bl.Dtos;

namespace VoidAggregator.Api.Models
{
    public class AuthorSong
    {
        public Author? Author { get; set; }
		public string AuthorId { get; set; }
		public Song? Song { get; set; }
		public int SongId { get; set; }
		public AuthorRole? AuthorRole { get; set; }
    }
}
