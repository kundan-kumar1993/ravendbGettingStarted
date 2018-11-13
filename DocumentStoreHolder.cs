using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using ravendb_getting_started.Indexes;
using ravendb_getting_started.Models;

namespace ravendb_getting_started
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private readonly ILogger<DocumentStoreHolder> _logger;

        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings, ILogger<DocumentStoreHolder> logger)
        {
            this._logger = logger;
            var settings = ravenSettings.Value;
            
            Store = new DocumentStore() {
                Urls = new [] { settings.Url },
                Database = settings.Database
            };
            Store.Initialize();

            CreateDatabaseIfNotExists();
            using(var session = Store.OpenSession()) {
                session.Load<Talk>("Talk/1");
            }

            this._logger.LogInformation("Initialized RevenDB document store for {0} at {1}", settings.Database, settings.Url);
            // TODO: Connect to RavenDB            
            this._logger.LogWarning("⚠️  Not connected to Raven document store");

            IndexCreation.CreateIndexes(
                typeof(Talks_BySpeaker).Assembly,
                Store
            );
        }
        public IDocumentStore Store { get; }

        private void CreateDatabaseIfNotExists()
        {
            var database = Store.Database;
            var dbRecord = Store.Maintenance.Server.Send(new GetDatabaseRecordOperation(database));

            if (dbRecord == null)
            {
                this._logger.LogInformation("RavenDB database does not exist, creating and seeding with initial data");

                // Create database
                var createResult = Store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord(database)));

                if (createResult.Name != null)
                {
                    // Seed database

                }
            }
        }
    }
}