using System.Collections.Generic;
using System.IO;

namespace ImportFile.Domain.Interfaces
{
    public interface ICSVClient
    {
        IList<T> ReadCSVFile<T>(Stream stream);
    }
}