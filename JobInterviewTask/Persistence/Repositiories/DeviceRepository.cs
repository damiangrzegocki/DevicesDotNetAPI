using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Repositories;
using JobInterviewTask.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobInterviewTask.Persistence.Repositiories
{
    public class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Device>> ListAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
        }

        public async Task<Device> FindByIdAsync(Guid id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public void Update(Device device)
        {
            _context.Devices.Update(device);
        }

        public void Remove(Device device)
        {
            _context.Devices.Remove(device);
        }
    }
}
