using JobInterviewTask.Domain.Models;

namespace JobInterviewTask.Domain.Services.Communication
{
    public class DeviceResponse : BaseResponse
    {
        public Device Device { get; private set; }

        private DeviceResponse(bool success, string message, Device device) : base(success, message)
        {
            Device = device;
        }

        public DeviceResponse(Device device) : this(true, string.Empty, device)
        {

        }

        public DeviceResponse(string message) : this(false, message, null)
        {

        }
    }
}
