using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobInterviewTask.Domain.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<Device>> ListAsync();
        Task<DeviceResponse> SaveAsync(Device device);
        Task<DeviceResponse> UpdateAsync(Guid id, Device device);
        Task<DeviceResponse> DeleteAsync(Guid id);
    }
}
