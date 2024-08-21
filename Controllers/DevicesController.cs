using IoTsmartAPI.Interface;
using IoTsmartAPI.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IoTsmartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Device>> GetDevices()
        {
            var devices = _deviceRepository.GetAllDevices();
            return Ok(devices);
        }

        [HttpGet("{macAddress}")]
        public ActionResult<Device> GetDeviceByMac(string macAddress)
        {
            var device = _deviceRepository.GetDeviceByMac(macAddress);
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpPost]
        public IActionResult AddDevice([FromBody] Device device)
        {
            if (device == null)
            {
                return BadRequest("Device cannot be null.");
            }

            device.Id = Guid.NewGuid().ToString();  // Generate a new GUID for the Id

            _deviceRepository.AddDevice(device);
            return CreatedAtAction(nameof(GetDeviceByMac), new { macAddress = device.MACAddress }, device);
        }

        [HttpPut("{macAddress}")]
        public IActionResult UpdateDevice(string macAddress, [FromBody] Device device)
        {
            if (device == null)
            {
                return BadRequest("Device cannot be null.");
            }

            var existingDevice = _deviceRepository.GetDeviceByMac(macAddress);
            if (existingDevice == null)
            {
                return NotFound();
            }

            device.MACAddress = macAddress;
            _deviceRepository.UpdateDevice(device);
            return NoContent();
        }

        [HttpDelete("{macAddress}")]
        public IActionResult DeleteDevice(string macAddress)
        {
            var device = _deviceRepository.GetDeviceByMac(macAddress);
            if (device == null)
            {
                return NotFound();
            }
            _deviceRepository.DeleteDevice(macAddress);
            return NoContent();
        }
    }
}
