using IoTsmartAPI.Models;
using System.Collections.Generic;

namespace IoTsmartAPI.Interface
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDeviceByMac(string macAddress);
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(string macAddress);
    }
}
