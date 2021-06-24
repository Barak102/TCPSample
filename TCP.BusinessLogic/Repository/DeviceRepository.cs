using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using TCP.Contract.Repository;
using TCP.Model;

namespace TCP.BusinessLogic.Repository
{
    public class DeviceRepository : IDeviceRepository
    {
        public List<DeviceBase> GetDevices()
        {
            return GetDevicesFromFile();
        }

        public void SaveDevice(DeviceBase device)
        {
           var devices = GetDevicesFromFile();
           DeviceBase selectedDevice = devices.Where(d => d.Id == device.Id).First();
            int index = devices.IndexOf(selectedDevice);
            if(index != -1)
            {
                devices[index] = device;
            }
            // save to json file
            File.WriteAllText("MOCK_DATA.json", JsonSerializer.Serialize(devices));
            
        }

        private List<DeviceBase> GetDevicesFromFile()
        {
            var data = File.ReadAllText("MOCK_DATA.json");
            return JsonSerializer.Deserialize<List<DeviceBase>>(data);
        }
    }
}
