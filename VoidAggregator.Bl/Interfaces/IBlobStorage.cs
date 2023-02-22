namespace VoidAggregator.Bl.Interfaces
{
    public interface IBlobStorage
    {
        public Task<string> AddItem(byte[] item);

        public Task<byte[]> GetItem(string key);
    }
}
