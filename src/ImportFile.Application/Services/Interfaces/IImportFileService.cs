using System.IO;
using System.Threading.Tasks;

namespace ImportFile.Application.Services.Interfaces
{
    public interface IImportFileService
    {
        Task UploadItemsByFileStream(Stream stream);
    }
}