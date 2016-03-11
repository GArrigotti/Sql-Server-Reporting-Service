using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Report_Downloader.Data
{
    public interface IQueryable : IDisposable
    {
        IList<TEntity> List<TEntity>(string query, CommandType commandType, params SqlParameter[] parameters) where TEntity : class, new();
    }
}
