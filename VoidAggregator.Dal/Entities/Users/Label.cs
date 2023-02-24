namespace VoidAggregator.Dal.Entities.Users
{
	public class Label : ApplicationUser
	{
		public List<Author> Authors { get; set; }

	}
}
