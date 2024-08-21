using IoTsmartAPI.Data;
using IoTsmartAPI.Interface;
using IoTsmartAPI.Models;
using IoTsmartAPI.Data;
using IoTsmartAPI.Interface;
using IoTsmartAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace IoTsmartAPI.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IMongoCollection<Device> _deviceCollection;

        public DeviceRepository(MongoDbContext context)
        {
            _deviceCollection = context.Devices;
        }

        public void AddDevice(Device device)
        {
            _deviceCollection.InsertOne(device);
        }

        public void DeleteDevice(string macAddress)
        {
            var filter = Builders<Device>.Filter.Eq(d => d.MACAddress, macAddress);
            _deviceCollection.DeleteOne(filter);
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return _deviceCollection.Find(_ => true).ToList();
        }

        public Device GetDeviceByMac(string macAddress)
        {
            var filter = Builders<Device>.Filter.Eq(d => d.MACAddress, macAddress);
            return _deviceCollection.Find(filter).FirstOrDefault();
        }

        public void UpdateDevice(Device device)
        {
            var filter = Builders<Device>.Filter.Eq(d => d.MACAddress, device.MACAddress);
            var update = Builders<Device>.Update
                .Set(d => d.IPAddress, device.IPAddress)
                .Set(d => d.DeviceName, device.DeviceName);
            _deviceCollection.UpdateOne(filter, update);
        }
    }
}
