using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Repositories;
using JobInterviewTask.Domain.Services;
using JobInterviewTask.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobInterviewTask.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IDeviceRepository deviceRepository, IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return await _deviceRepository.ListAsync();
        }

        public async Task<DeviceResponse> SaveAsync(Device device)
        {
            try
            {
                await _deviceRepository.AddAsync(device);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(device);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Saving error: {ex.Message}");
            }
        }

        public async Task<DeviceResponse> UpdateAsync(Guid id, Device device)
        {
            var existDevice = await _deviceRepository.FindByIdAsync(id);

            if (existDevice == null)
            {
                return new DeviceResponse("Device does not exist.");
            }

            existDevice.Name = device.Name;
            existDevice.Description = device.Description;
            existDevice.Disabled = device.Disabled;

            try
            {
                _deviceRepository.Update(existDevice);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(existDevice);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Updating error: {ex.Message}");
            }
        }

        public async Task<DeviceResponse> DeleteAsync(Guid id)
        {
            var existDevice = await _deviceRepository.FindByIdAsync(id);

            if (existDevice == null)
            {
                return new DeviceResponse("Device does not exist.");
            }
            
            try
            {
                _deviceRepository.Remove(existDevice);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(existDevice);
            }
            catch (Exception ex)
            {
                return new DeviceResponse($"Deleting error: {ex.Message}");
            }
        }
    }
}
