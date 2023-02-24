namespace VoidAggregator.Dal.Db
{
	public class DbInitializer
	{
		public static void Initialize(VoidAggregatorContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
