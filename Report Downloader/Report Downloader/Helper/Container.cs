using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Downloader.Helper
{
    public class Container
    {
        Dictionary<Type, object> mapping;

        #region Constructor:

        public Container()
        {
            mapping = new Dictionary<Type, object>();
        }

        #endregion

        public void Map<TIn, TOut>(params object[] argument)
        {
            if(!mapping.ContainsKey(typeof(TIn)))
            {
                var instance = Activator.CreateInstance(typeof(TOut), argument);
                mapping[typeof(TIn)] = instance;
            }
        }

        public TContext GetDataContext<TContext>() where TContext : class
        {
            if (mapping.ContainsKey(typeof(TContext)))
                return mapping[typeof(TContext)] as TContext;

            throw new ApplicationException(String.Format("The dependency injection container failed to register the following type {0}", typeof(TContext).Name));
        }
    }
}
