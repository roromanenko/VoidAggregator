namespace VoidAggregator.Api.Models.Authorization
{
	public class SignResponse<T> where T : User
	{
		public string Token { get; set; }
		public DateTime ExpiredAt { get; set; }
		public T User { get; set; }
	}
}
