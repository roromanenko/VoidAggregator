using System.ComponentModel.DataAnnotations.Schema;

namespace VoidAggregator.Dal.Entities.Users
{
    [Table(nameof(Label))]
    public class Label : ApplicationUser
	{
		public List<Author> Authors { get; set; } = new List<Author>();
	}
}
