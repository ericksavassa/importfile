using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImportFile.Domain.Interfaces
{
    public interface IItemDbRepository
    {
        Task<IEnumerable<Item>> GetAll();

        Task<Item> GetByKey(string Key);

        Task Create(Item item);

        Task<bool> Update(Item item);
    }
}