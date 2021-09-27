using ImportFile.Domain;
using ImportFile.Domain.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ImportFile.Infrastructure.Repositories.Mongo
{
    public class ItemDbRepository : IItemDbRepository
    {
        private readonly IImportFileContext Context;

        public ItemDbRepository(IImportFileContext context)
        {
            this.Context = context;
        }

        public async Task Create(Item item)
        {
            await this.Context.Items.InsertOneAsync(item);
        }

        public async Task<bool> Update(Item item)
        {
            ReplaceOneResult updateResult =
                await this.Context
                        .Items
                        .ReplaceOneAsync(
                            filter: g => g.Key == item.Key,
                            replacement: item);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            var records = await this.Context
                          .Items
                          .Find(_ => true)
                          .ToListAsync();
            return records;
        }

        public async Task<Item> GetByKey(string key)
        {
            Expression<Func<Item, bool>> filter = x => x.Key.Equals(key);
            Item item = await this.Context.Items.Find<Item>(filter).FirstOrDefaultAsync();
            return item;
        }
    }
}