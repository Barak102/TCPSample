using System;
using System.Collections.Generic;
using TCP.Contract.Data;
using TCP.Model;

namespace TCP.Contract
{
    public interface IDeviceManager
    {
        GetDevicesResponse GetDevices(GetDevicesRequest request);
        ChangeStateResponse ChangeState(ChangeStateRequest request);
        SetValueResponse SetValue(SetValueRequest request);
    }
}
