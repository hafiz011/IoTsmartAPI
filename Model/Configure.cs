using IoTsmartAPI.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

public static class MongoDbConfiguration
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<ApplicationUser>(cm =>
        {
            cm.AutoMap();
            cm.SetIdMember(cm.GetMemberMap(c => c.Id));
        });
    }
}
