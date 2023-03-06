namespace VoidAggregator.Bl.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
		public List<string> Roles { get; set; }
	}
}
