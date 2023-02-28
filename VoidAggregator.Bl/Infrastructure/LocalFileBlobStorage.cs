using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			string path = Path.Combine(_storageOptions.Path, fileKey);

			await File.WriteAllBytesAsync(path, item);

			return path;
		}

		public Task<byte[]> GetItem(string key)
		{
			string path = Path.Combine(_storageOptions.Path, key);

			return File.ReadAllBytesAsync(path);
		}
	}
}
