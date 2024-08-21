using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IoTsmartAPI.Models
{
    public class ControlCommand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DeviceId { get; set; }  // Reference to the device ID
        public CommandType Command { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public enum CommandType
    {
        TurnOn,
        TurnOff,
        SetTemperature,
        AdjustBrightness,
        Other
    }
}
