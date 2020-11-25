using JobInterviewTask.Controllers;
using JobInterviewTask.Domain.Models;
using JobInterviewTask.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ApiUnitTest
{
    public class UnitTest
    {
        DevicesController _controller;
        IDeviceService _service;

        public UnitTest()
        {
            _service = new FakeDeviceService();
            _controller = new DevicesController(_service);
        }

        [Fact]
        public async void PostRequest_ValidObjectPassed_IfResponseCreatedItem()
        {
            // Arrange
            var testItem = new Device()
            {
                Name = "Tesla",
                Description = "Automotive",
                Disabled = false
            };

            // Act
            IActionResult response = await _controller.PostAsync(testItem);
            var result = response as OkObjectResult;
            var checkItem = result.Value as Device;

            // Assert
            Assert.IsType<Device>(checkItem);
            Assert.Equal("Tesla", checkItem.Name);
            Assert.Equal("Automotive", checkItem.Description);
            Assert.Equal("False", checkItem.Disabled.ToString());
        }
    }
}
