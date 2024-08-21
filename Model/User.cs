using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IoTsmartAPI.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }  // Store hashed passwords
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
