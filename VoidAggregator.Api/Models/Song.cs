using VoidAggregator.Api.Models.Enums;

namespace VoidAggregator.Api.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? SongName { get; set; }
        public List<AuthorSong> AuthorsSongs { get; set; } = new List<AuthorSong>();
        public Language? Language { get; set; }
        public string? SongText { get; set; }
        public bool? IsExplicitContent { get; set; }
        public byte[]? SongContent { get; set; }
    }
}