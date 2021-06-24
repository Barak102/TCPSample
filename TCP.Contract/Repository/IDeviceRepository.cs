using System;
using System.Collections.Generic;
using System.Text;
using TCP.Model;

namespace TCP.Contract.Repository
{
    public interface IDeviceRepository
    {
        List<DeviceBase> GetDevices();
        void SaveDevice(DeviceBase device);
    }
}
