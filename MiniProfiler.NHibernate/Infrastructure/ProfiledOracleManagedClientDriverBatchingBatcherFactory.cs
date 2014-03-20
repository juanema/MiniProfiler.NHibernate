using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate.AdoNet;
using NHibernate.Engine;
using NHibernate;

namespace StackExchange.Profiling.NHibernate.Infrastructure
{
    internal class ProfiledOracleManagedClientDriverBatchingBatcherFactory : OracleDataClientBatchingBatcherFactory
    {
        public override IBatcher CreateBatcher(ConnectionManager connectionManager, IInterceptor interceptor)
        {
            return new ProfiledOracleManagedClientBatchingBatcher(connectionManager, interceptor);
        }
    }
}
