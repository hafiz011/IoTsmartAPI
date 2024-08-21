using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Identity;

namespace IoTsmartAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; }
    }
}
