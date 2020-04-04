using System;
using Microsoft.AspNetCore.SignalR;
using SignalRCore.Web.Extensions;
using SignalRCore.Web.Models;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace SignalRCore.Web.Hubs
{
    public class ReleaseDatabaseSubscription : IDatabaseSubscription
    {
        private readonly IHubContext<ReleaseHub> _hubContext;
        private bool _disposedValue = false;
        private SqlTableDependency<ReleaseModel> _tableDependency;

        public ReleaseDatabaseSubscription(IHubContext<ReleaseHub> hubContext)
        {
            _hubContext = hubContext;
        }
        
        public void Configure(string connectionString)
        {
            _tableDependency = new SqlTableDependency<ReleaseModel>(connectionString, null, null, null, null, null, DmlTriggerType.All);
            _tableDependency.OnChanged += Changed;
            _tableDependency.OnError += TableDependency_OnError;
            _tableDependency.Start();

            Console.WriteLine("Waiting for receiving notifications...");
        }
        
        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"SqlTableDependency error: {e.Error.Message}", e);
        }

        private void Changed(object sender, RecordChangedEventArgs<ReleaseModel> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                // TODO: manage the changed entity
                var changedEntity = e.Entity;
                _hubContext.Clients.All.SendAsync("UpdateRelease", changedEntity);
            }
        }
        
        #region IDisposable

        ~ReleaseDatabaseSubscription()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _tableDependency.Stop();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}