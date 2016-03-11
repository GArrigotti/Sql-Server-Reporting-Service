using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Configuration;
using Report_Downloader.Helper.Attributes;
using System.ComponentModel;

namespace Report_Downloader.Data
{
    public class DataContext : IQueryable
    {
        private Component component;
        private bool disposed = false;

        private readonly string dbConnection = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

        #region Constructor:

        public DataContext()
        {
            this.component = new Component();
        }

        #endregion

        IList<TEntity> IQueryable.List<TEntity>(string query, CommandType commandType, params SqlParameter[] parameters)
        {
            var collection = new List<TEntity>();
            var allocation = GetPropertyNameAndAttribute<TEntity>();

            using (var connection = new SqlConnection(dbConnection))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.CommandType = commandType;

                foreach (var parameter in parameters)
                    command.Parameters.Add(parameter);

                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var entity = new TEntity();
                        BuildEntity(reader, allocation, ref entity);
                        collection.Add(entity);
                    }
            }

            return collection;
        }

        #region Protected Helper:

        protected void BuildEntity<TEntity>(IDataReader reader, Dictionary<string, string> properties, ref TEntity model)
        {
            var table = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToArray();
            foreach(var column in table)
            {
                var matchColumnToProperty = properties.SingleOrDefault(property => String.Compare(property.Key, column) == 0).Key;
                var matchColumnToAttribute = properties.SingleOrDefault(property => String.Compare(property.Value, column) == 0).Value;

                if (matchColumnToProperty != null)
                    if (!reader.IsDBNull(reader.GetOrdinal(matchColumnToProperty)))
                        typeof(TEntity).GetProperty(matchColumnToProperty).SetValue(model, reader.GetValue(reader.GetOrdinal(matchColumnToProperty)), null);

                if (matchColumnToAttribute != null)
                    if (!reader.IsDBNull(reader.GetOrdinal(matchColumnToAttribute)))
                        typeof(TEntity).GetProperty(properties.SingleOrDefault(property => String.Compare(property.Value, matchColumnToAttribute) == 0).Key)
                            .SetValue(model, reader.GetValue(reader.GetOrdinal(matchColumnToAttribute)), null);                                       
            }            
        }

        protected Dictionary<string, string> GetPropertyNameAndAttribute<TEntity>()
        {
            var properties = typeof(TEntity).GetProperties();
            var collection = new Dictionary<string, string>();
            foreach(var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach(var attribute in attributes)
                {
                    var columnAttribute = attribute as ColumnAttribute;
                    if (columnAttribute != null)
                        collection.Add(property.Name, columnAttribute.Column);
                }
            }

            return collection;
        }

        #endregion

        #region Dispose:

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    component.Dispose();

                disposed = true;
            }
        }

        ~DataContext() { Dispose(false); }

        #endregion
    }
}
