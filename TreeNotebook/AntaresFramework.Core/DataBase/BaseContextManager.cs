using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntaresFramework.Core.DataBase
{
    public class BaseContextManager<T>  where T : DbContext, IDisposable, new()
    {
        private T context;
        public T Context
        {
            get
            {
                if (context == null)
                {
                    context = new T();
                }
                return context;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
