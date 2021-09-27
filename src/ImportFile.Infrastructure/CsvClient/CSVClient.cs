using CsvHelper;
using ImportFile.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImportFile.Infrastructure.CSVClient
{
    public class CSVClient : ICSVClient
    {
        public IList<T> ReadCSVFile<T>(Stream stream)
        {
            try
            {
                using var reader = new StreamReader(stream);
                using var csvReader = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<T>().ToList();
                return records;
            }
            catch
            {
                throw new Exception("Error trying to read csv file!");
            }
        }
    }
}