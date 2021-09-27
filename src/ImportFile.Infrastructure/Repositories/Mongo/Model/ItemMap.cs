using ImportFile.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace ImportFile.Infrastructure.Repositories.Mongo.Model
{
    public static class ItemMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Item>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapIdField(x => x.Id).SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(BsonType.ObjectId));
                map.MapMember(x => x.Key).SetIsRequired(true);
                map.MapMember(x => x.Code);
                map.MapMember(x => x.Color);
                map.MapMember(x => x.ColorCode);
                map.MapMember(x => x.DeliveredIn);
                map.MapMember(x => x.Description);
                map.MapMember(x => x.DiscountPrice);
                map.MapMember(x => x.Index);
                map.MapMember(x => x.Price);
                map.MapMember(x => x.Size);
            });
        }
    }
}