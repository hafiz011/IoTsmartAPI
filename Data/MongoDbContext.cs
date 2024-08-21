using MongoDB.Driver;
using IoTsmartAPI.Models;
using IoTsmartAPI.Models.Settings;
using Microsoft.Extensions.Options;

namespace IoTsmartAPI.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Define your collections here
        public IMongoCollection<Device> Devices => _database.GetCollection<Device>("Devices");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Group> Groups => _database.GetCollection<Group>("Groups");
        public IMongoCollection<SensorData> SensorData => _database.GetCollection<SensorData>("SensorData");
        public IMongoCollection<ControlCommand> ControlCommands => _database.GetCollection<ControlCommand>("ControlCommands");
        public IMongoCollection<Configuration> Configurations => _database.GetCollection<Configuration>("Configurations");
    }
}
