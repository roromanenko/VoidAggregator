using VoidAggregator.Dal;

namespace VoidAggregator.Bl.Dtos
{
	public class AuthorDto : UserDto
	{
		public List<AuthorSongDto> AuthorsSongs { get; set; } = new List<AuthorSongDto>();
		public List<ReleaseDto> Releases { get; set; } = new List<ReleaseDto>();
		public LabelDto Label { get; set; }
		public string LabelId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
