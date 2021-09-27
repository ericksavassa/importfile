using ImportFile.Domain.Common.Extensions;
using ImportFile.Domain.DTOs;

namespace ImportFile.Domain.Maps
{
    public static class MapItemDtoToItem
    {
        public static Item MapItem(ItemCsvDTO itemDTO)
        {
            var price = itemDTO.Price.ToDouble();
            var discount = itemDTO.DiscountPrice.ToDouble();
            var size = itemDTO.Size.ToInt32();

            return new Item(itemDTO.Key,
                itemDTO.ArtikelCode,
                itemDTO.Description,
                price,
                discount,
                itemDTO.DeliveredIn,
                itemDTO.Q1,
                size,
                itemDTO.Color,
                itemDTO.ColorCode);
        }
    }
}