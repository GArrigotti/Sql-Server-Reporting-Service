namespace Report_Downloader.Data
{
    public class DataContextFactory : IFactory
    {
        public IQueryable CreateQuery()
        {
            return new DataContext();
        }
    }
}
