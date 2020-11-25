using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Services;
using JobInterviewTask.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUnitTest
{
    class FakeDeviceService : IDeviceService
    {
        private readonly List<Device> _device;

        public FakeDeviceService()
        {
            _device = new List<Device>()
            {
                new Device() { Id = Guid.NewGuid(),
                    Name = "Test1", Description="Test1", Disabled = true },
                new Device() { Id = Guid.NewGuid(),
                    Name = "Test2", Description="Test2", Disabled = false },
            };
        }

        public async Task<DeviceResponse> DeleteAsync(Guid id)
        {
            var existDevice = _device.First(a => a.Id == id);
            
            if (existDevice == null)
            {
                return new DeviceResponse("Device does not exist.");
            }

            try
            {
                _device.Remove(existDevice);

                return new DeviceResponse(existDevice);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Deleting error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return _device;
        }

        public async Task<DeviceResponse> SaveAsync(Device newItem)
        {
            try
            {
                newItem.Id = Guid.NewGuid();
                _device.Add(newItem);

                return new DeviceResponse(newItem);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Saving error: {ex.Message}");
            }
        }

        public async Task<DeviceResponse> UpdateAsync(Guid id, Device device)
        {
            var existDevice = _device.Where(a => a.Id == id).FirstOrDefault();

            if (existDevice == null)
            {
                return new DeviceResponse("Device does not exist.");
            }

            existDevice.Name = device.Name;
            existDevice.Description = device.Description;
            existDevice.Disabled = device.Disabled;

            try
            {
                //TODO

                return new DeviceResponse(existDevice);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Updating error: {ex.Message}");
            }
        }
    }
}
