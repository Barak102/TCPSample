using System;
using System.Linq;
using TCP.Contract;
using TCP.Contract.Data;
using TCP.Contract.Repository;

namespace TCP.BusinessLogic
{
    public class DeviceManager : IDeviceManager
    {
        private readonly IDeviceRepository _repository;
        public DeviceManager(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public ChangeStateResponse ChangeState(ChangeStateRequest request)
        {
            var devices = _repository.GetDevices();
            var selectedDevice = devices.FirstOrDefault(d => d.Id == request.Id);
            selectedDevice.IsActive = request.IsActive;
            _repository.SaveDevice(selectedDevice);
            return new ChangeStateResponse()
            {
                IsSucceed = true
            };
        }

        public GetDevicesResponse GetDevices(GetDevicesRequest request)
        {
            return new GetDevicesResponse()
            {
                Devices = _repository.GetDevices()
            };
        }
           
        public SetValueResponse SetValue(SetValueRequest request)
        {
            var devices = _repository.GetDevices();
            var selectedDevice = devices.FirstOrDefault(d => d.Id == request.Id);
            selectedDevice.Value = request.Value;
            _repository.SaveDevice(selectedDevice);
            return new SetValueResponse()
            {
                IsSucceed = true
            };
        }
    }
}
