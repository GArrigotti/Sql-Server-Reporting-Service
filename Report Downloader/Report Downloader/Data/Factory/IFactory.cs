namespace Report_Downloader.Data
{
    public interface IFactory : IQueryableFactory
    {
        // Important:
        // Will simply act as a container, for all of our interface factories.
    }

    public interface IQueryableFactory
    {
        IQueryable CreateQuery();
    }
}
