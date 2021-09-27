using ImportFile.Application.Services.Interfaces;
using ImportFile.Domain;
using ImportFile.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImportFile.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemDbRepository IItemDbRepository;

        public ItemService(IItemDbRepository itemDbRepository)
        {
            this.IItemDbRepository = itemDbRepository;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await this.IItemDbRepository.GetAll();
        }

        public async Task<Item> GetByKey(string key)
        {
            return await this.IItemDbRepository.GetByKey(key);
        }

        public async Task SaveItem(Item item)
        {
            var storedItem = await GetByKey(item.Key);
            if (storedItem == null)
            {
                await this.IItemDbRepository.Create(item);
            }
            else
            {
                item.SetId(storedItem.Id);
                await this.IItemDbRepository.Update(item);
            }
        }
    }
}