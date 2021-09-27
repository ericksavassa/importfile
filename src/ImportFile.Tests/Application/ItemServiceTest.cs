using ImportFile.Application.Services;
using ImportFile.Domain;
using ImportFile.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ImportFile.Tests.Application
{
    public class ItemServiceTest
    {
        [Fact]
        public async Task GetAll_With_Values_Success()
        {
            //arrange
            var repository = new Mock<IItemDbRepository>();
            var itemList = new List<Item>()
            {
                BuildItem()
            };
            repository.Setup(p => p.GetAll()).ReturnsAsync(itemList);
            var service = new ItemService(repository.Object);

            //act
            var result = await service.GetAll();

            //assert
            repository.Verify(p => p.GetAll(), Times.Once);
            Assert.Equal(itemList.Count, result.Count());
        }

        [Fact]
        public async Task GetByKey_With_Values_Success()
        {
            //arrange
            var key = "key";
            var repository = new Mock<IItemDbRepository>();
            var item = BuildItem();

            repository.Setup(p => p.GetByKey(key)).ReturnsAsync(item);
            var service = new ItemService(repository.Object);

            //act
            var result = await service.GetByKey(key);

            //assert
            repository.Verify(p => p.GetByKey(key), Times.Once);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task SaveItem_Found_Item_Should_Update_Success()
        {
            //arrange
            var repository = new Mock<IItemDbRepository>();
            var item = BuildItem();

            repository.Setup(p => p.GetByKey(item.Key)).ReturnsAsync(item);
            var service = new ItemService(repository.Object);

            //act
            await service.SaveItem(item);

            //assert
            repository.Verify(p => p.GetByKey(item.Key), Times.Once);
            repository.Verify(p => p.Update(It.IsAny<Item>()), Times.Once);
        }

        [Fact]
        public async Task SaveItem_NotFound_Item_Should_Create_Success()
        {
            //arrange
            var repository = new Mock<IItemDbRepository>();
            var item = BuildItem();
            Item nullItem = null;

            repository.Setup(p => p.GetByKey(item.Key)).ReturnsAsync(nullItem);
            var service = new ItemService(repository.Object);

            //act
            await service.SaveItem(item);

            //assert
            repository.Verify(p => p.GetByKey(item.Key), Times.Once);
            repository.Verify(p => p.Create(It.IsAny<Item>()), Times.Once);
        }

        private Item BuildItem()
        {
            return new Item("key",
                "code",
                "description",
                10,
                1,
                "deliveredIn",
                "index",
                5,
                "color",
                "colorCode");
        }
    }
}