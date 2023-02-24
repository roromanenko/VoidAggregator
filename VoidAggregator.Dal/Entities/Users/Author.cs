namespace VoidAggregator.Dal.Entities.Users
{
	public class Author : ApplicationUser
	{
		public List<Release> Releases { get; set; }
		public int? LabelId { get; set; }
		public Label Label { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<AuthorSong> AuthorsSongs { get; set; }
	}
}
