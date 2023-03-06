using VoidAggregator.Bl.Dtos;
using VoidAggregator.Dal;

namespace VoidAggregator.Api.Models
{
	public class Author : User
	{
		public List<AuthorSong> AuthorsSongs { get; set; } = new List<AuthorSong>();
		public List<Release> Releases { get; set; } = new List<Release>();
		public Label? Label { get; set; }
		public string LabelId { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
