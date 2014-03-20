using System;
using System.Data;
using System.Data.Common;

using NHibernate.AdoNet;
using NHibernate.Driver;
using StackExchange.Profiling.NHibernate.Infrastructure;
using Oracle.ManagedDataAccess.Client;


namespace StackExchange.Profiling.NHibernate.Drivers.Oracle
{
    public class MiniProfilerOracleManagedClientDriver : OracleManagedDataClientDriver, IEmbeddedBatcherFactoryProvider
    {
        public override IDbCommand CreateCommand()
        {
            var command = base.CreateCommand();
            // TEST JBL 20140317
            ((OracleCommand)command).BindByName = true;
            // END TEST JBL 20140317
            if (MiniProfiler.Current != null)
            {
                command = new ProfiledGenericDbCommand<OracleCommand>((DbCommand)command, MiniProfiler.Current);
            }

            return command;
        }        

        protected override void OnBeforePrepare(IDbCommand command)
        {
            IDbCommand v_command = null;

            if (command is ProfiledGenericDbCommand<OracleCommand>)
            {
                v_command = ((ProfiledGenericDbCommand<OracleCommand>)command).InternalCommand;
            }
            else
            {
                v_command = command;
            }

            base.OnBeforePrepare(v_command);
        }

        Type IEmbeddedBatcherFactoryProvider.BatcherFactoryClass
        {
            get { return typeof(ProfiledOracleManagedClientDriverBatchingBatcherFactory); }
        }

    }
}