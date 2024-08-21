using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IoTsmartAPI.Models
{
    public class SensorData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DeviceId { get; set; }  // Reference to the device ID
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public double Value { get; set; }  // Sensor value (e.g., temperature, humidity)
    }
}
