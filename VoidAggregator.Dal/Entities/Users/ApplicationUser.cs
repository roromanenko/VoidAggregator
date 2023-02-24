using Microsoft.AspNetCore.Identity;

namespace VoidAggregator.Dal.Entities.Users
{
	public class ApplicationUser : IdentityUser
	{
		public string Title { get; set; }
		public string Country { get; set; }
	}
}
