using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IoTsmartAPI.Models
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public string DeviceName { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

    }
}
