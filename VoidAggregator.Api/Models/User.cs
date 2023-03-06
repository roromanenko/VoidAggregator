namespace VoidAggregator.Api.Models
{
    public class User
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
		public List<string>? Roles { get; set; }
	}
}
