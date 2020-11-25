using JobInterviewTask.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobInterviewTask.Domain.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> ListAsync();
        Task AddAsync(Device device);
        Task<Device> FindByIdAsync(Guid id);
        void Update(Device device);
        void Remove(Device device);
    }
}
