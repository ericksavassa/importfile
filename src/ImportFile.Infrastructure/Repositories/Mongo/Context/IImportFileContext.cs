using ImportFile.Domain;
using MongoDB.Driver;

namespace ImportFile.Infrastructure.Repositories.Mongo
{
    public interface IImportFileContext
    {
        IMongoCollection<Item> Items { get; }
    }
}