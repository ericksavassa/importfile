namespace ImportFile.Domain
{
    public class Item
    {
        public Item(string key,
            string code,
            string description,
            double price,
            double discountPrice,
            string deliveredIn,
            string index,
            int size,
            string color,
            string colorCode)
        {
            this.Key = key;
            this.Code = code;
            this.Description = description;
            this.Price = price;
            this.DiscountPrice = discountPrice;
            this.DeliveredIn = deliveredIn;
            this.Index = index;
            this.Size = size;
            this.Color = color;
            this.ColorCode = colorCode;
        }

        public string Id { get; private set; }
        public string Key { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public double DiscountPrice { get; private set; }
        public string DeliveredIn { get; private set; }
        public string Index { get; private set; }
        public int Size { get; private set; }
        public string Color { get; private set; }
        public string ColorCode { get; private set; }

        public void SetId(string id)
        {
            this.Id = id;
        }
    }
}