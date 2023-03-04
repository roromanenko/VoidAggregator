using Microsoft.Extensions.Options;
using System.Reflection;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Bl.Settings;

namespace VoidAggregator.Bl.Infrastructure
{
	public class LocalFileBlobStorage : IBlobStorage
	{
		private readonly StorageSetting _storageOptions;

		public LocalFileBlobStorage(IOptions<StorageSetting> storageOptions)
		{
			_storageOptions = storageOptions.Value;
		}

		public async Task<string> AddItem(byte[] item)
		{
			string fileKey = Guid.NewGuid().ToString();
			var directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, _storageOptions.Path);
			Directory.CreateDirectory(directory);
			string path = Path.Combine(directory, fileKey);

			await File.WriteAllBytesAsync(path, item);

			return fileKey;
		}

		public Task<byte[]> GetItem(string key)
		{
			var directory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, _storageOptions.Path);
			string path = Path.Combine(directory, key);

			return File.ReadAllBytesAsync(path);
		}
	}
}
