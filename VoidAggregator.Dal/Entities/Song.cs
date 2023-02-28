using VoidAggregator.Dal.Entities.Enums;

namespace VoidAggregator.Dal.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string SongName { get; set; }
        public Language Language { get; set; }
        public string SongText { get; set; }
        public bool IsExplicitContent { get; set; }
        public string SongContentPath { get; set; }
		public int ReleaseId { get; set; }
		public Release Release { get; set; }
		public List<AuthorSong> AuthorsSongs { get; set; }
	}
}