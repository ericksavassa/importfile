using ImportFile.Application.Services;
using ImportFile.Application.Services.Interfaces;
using ImportFile.Domain;
using ImportFile.Domain.DTOs;
using ImportFile.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace ImportFile.Tests.Application
{
    public class ImportFileServiceTest
    {
        [Fact]
        public async Task UploadItemsByFileStream_With_Values_Success()
        {
            //arrange
            var csvClient = new Mock<ICSVClient>();
            var itemService = new Mock<IItemService>();
            var repository = new Mock<IItemJsRepository>();
            var records = new List<ItemCsvDTO>() { BuildItem() };

            csvClient.Setup(p => p.ReadCSVFile<ItemCsvDTO>(It.IsAny<Stream>())).Returns(records);
            var service = new ImportFileService(csvClient.Object, itemService.Object, repository.Object);

            //act
            await service.UploadItemsByFileStream(It.IsAny<Stream>());

            //assert
            csvClient.Verify(p => p.ReadCSVFile<ItemCsvDTO>(It.IsAny<Stream>()), Times.Once);
            itemService.Verify(p => p.SaveItem(It.IsAny<Item>()), Times.Exactly(records.Count));
            repository.Verify(p => p.Save(It.IsAny<IList<ItemCsvDTO>>()), Times.Once);
        }

        private ItemCsvDTO BuildItem()
        {
            return new ItemCsvDTO();
        }
    }
}