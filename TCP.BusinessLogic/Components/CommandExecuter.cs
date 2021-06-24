using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using TCP.Contract;
using TCP.Contract.Components;
using TCP.Contract.Data;

namespace TCP.BusinessLogic.Components
{
    public class CommandExecuter : ICommandExecuter
    {
        private readonly IDeviceManager _deviceManager;

        public CommandExecuter(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        public string ChangeState(string request)
        {
            string[] requestParams = request.Split(" ");

            var response = _deviceManager.ChangeState(new ChangeStateRequest()
            {
                Id = int.Parse(requestParams[1]),
                IsActive = bool.Parse(requestParams[2])
            }
                );
            return ConvertToJson<ChangeStateResponse>(response);
        }

        public string GetDevices(string request)
        {
            var response = _deviceManager.GetDevices(new GetDevicesRequest());
            return ConvertToJson<GetDevicesResponse>(response);
        }

        public string SetValue(string request)
        {
            string[] requestParams = request.Split(" ");
            var response = _deviceManager.SetValue(new SetValueRequest()
            {
                Id = int.Parse(requestParams[1]),
                Value = int.Parse(requestParams[2])
            }
                );
            return ConvertToJson<SetValueResponse>(response);
        }

        private string ConvertToJson<T>(T data)
        {
            return JsonSerializer.Serialize<T>(data, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
