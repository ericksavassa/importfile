using ImportFile.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImportFile.Application.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAll();

        Task<Item> GetByKey(string key);

        Task SaveItem(Item item);
    }
}