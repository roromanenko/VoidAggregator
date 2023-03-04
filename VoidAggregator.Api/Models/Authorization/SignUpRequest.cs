namespace VoidAggregator.Api.Models.Authorization
{
	public class SignUpRequest<T> where T : User
	{
		public T User { get; set; }
		public string Password { get; set; }
	}
}
