using ImportFile.Application.Services.Interfaces;
using ImportFile.Domain;
using ImportFile.Domain.DTOs;
using ImportFile.Domain.Interfaces;
using ImportFile.Domain.Maps;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImportFile.Application.Services
{
    public class ImportFileService : IImportFileService
    {
        private readonly ICSVClient CSVClient;
        private readonly IItemService ItemService;
        private readonly IItemJsRepository ItemJsRepository;

        public ImportFileService(ICSVClient csvClient, IItemService itemService, IItemJsRepository itemJsRepository)
        {
            this.CSVClient = csvClient;
            this.ItemService = itemService;
            this.ItemJsRepository = itemJsRepository;
        }

        public async Task UploadItemsByFileStream(Stream stream)
        {
            var records = this.CSVClient.ReadCSVFile<ItemCsvDTO>(stream);
            var itemList = records.Select(r => MapItemDtoToItem.MapItem(r)).ToList();

            await StoreIntoDb(itemList);
            await StoreIntoJs(records);
        }

        private async Task StoreIntoDb(List<Item> itemList)
        {
            foreach (var item in itemList)
                await this.ItemService.SaveItem(item);
        }

        private async Task StoreIntoJs(IList<ItemCsvDTO> itemList)
        {
            await this.ItemJsRepository.Save<IList<ItemCsvDTO>>(itemList);
        }
    }
}