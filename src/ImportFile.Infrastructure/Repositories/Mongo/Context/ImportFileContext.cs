using ImportFile.Domain;
using ImportFile.Infrastructure.Repositories.Mongo.Model;
using MongoDB.Driver;

namespace ImportFile.Infrastructure.Repositories.Mongo
{
    public class ImportFileContext : IImportFileContext
    {
        private readonly IMongoDatabase Db;

        public ImportFileContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            this.Db = client.GetDatabase(config.Database);
        }

        public IMongoCollection<Item> Items => this.Db.GetCollection<Item>("Items");
    }
}