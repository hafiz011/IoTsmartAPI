﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IoTsmartAPI.Models
{
    public class Configuration
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
