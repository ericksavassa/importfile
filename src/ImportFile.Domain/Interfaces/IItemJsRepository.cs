using System.Threading.Tasks;

namespace ImportFile.Domain.Interfaces
{
    public interface IItemJsRepository
    {
        Task Save<T>(T itemList);
    }
}