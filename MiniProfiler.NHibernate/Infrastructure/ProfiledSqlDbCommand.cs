using System.Data.Common;
using System.Data.SqlClient;
using StackExchange.Profiling.Data;
using System;

namespace StackExchange.Profiling.NHibernate.Infrastructure
{
    [Obsolete]
    public class ProfiledSqlDbCommand : ProfiledDbCommand
    {
        private readonly SqlCommand _sqlCommand;

        public ProfiledSqlDbCommand(DbCommand command, IDbProfiler profiler) : base(command, null, profiler)
        {
            _sqlCommand = (SqlCommand)command;
        }

        public SqlCommand SqlCommand
        {
            get { return _sqlCommand; }
        }
    }
}