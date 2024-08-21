using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IoTsmartAPI.Models
{
    public class Group
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string GroupName { get; set; }
        public List<string> DeviceIds { get; set; } = new List<string>();  // Store references to device IDs
        public string UserId { get; set; }  // Reference to the user who created the group
    }
}
