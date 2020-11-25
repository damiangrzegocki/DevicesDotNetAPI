using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobInterviewTask.Extensions;
using System;

namespace JobInterviewTask.Controllers
{
    [Route("/api/[controller]")]
    public class DevicesController : Controller
    {
        private readonly IDeviceService _deviceService;

        public DevicesController (IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            var devices = await _deviceService.ListAsync();

            return devices;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Device resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _deviceService.SaveAsync(resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Device resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var result = await _deviceService.UpdateAsync(id, resource);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Device);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _deviceService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Device);
        }
    }
}
