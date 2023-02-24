namespace VoidAggregator.Dal.Db
{
	internal class DbInitializer
	{
		internal static void Initialize(VoidAggregatorContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
