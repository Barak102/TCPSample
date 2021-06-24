using System.Collections.Generic;
using TCP.Model;

namespace TCP.Contract.Data
{
    public class GetDevicesResponse
    {
        public List<DeviceBase> Devices { get; set; }
    }
}
