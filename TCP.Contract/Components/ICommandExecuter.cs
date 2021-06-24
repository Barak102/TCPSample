using System;
using System.Collections.Generic;
using System.Text;

namespace TCP.Contract.Components
{
    public interface ICommandExecuter
    {
       string GetDevices(string request);
       string ChangeState(string request);
       string SetValue(string request);
    }
}
