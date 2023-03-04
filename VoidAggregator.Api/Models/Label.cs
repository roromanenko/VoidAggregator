using VoidAggregator.Dal;

namespace VoidAggregator.Api.Models
{
	public class Label : User
	{
		public List<Author> Authors { get; set; } = new List<Author>();
	}
}
