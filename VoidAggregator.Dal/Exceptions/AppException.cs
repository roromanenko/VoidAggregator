namespace VoidAggregator.Dal.Exceptions
{
	public class AppException : Exception
	{
		public AppException() { }
		public AppException(string message) : base(message) { }
		public AppException(string message, Exception inner) : base(message, inner) { }

		public const string IncorrectLogin = "Login or/and password is incorrect";
		public const string CannotCreateUser = "Cannot create user";
	}
}
