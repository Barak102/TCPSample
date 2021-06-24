using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using TCP.Contract;
using TCP.Contract.Components;
using TCP.Model;

namespace TCP.Server
{
    delegate string DeviceAction(string message);

    public class TCPServer : IServerProvider
    {
        private readonly ICommandExecuter _commandExecuter;
        private Dictionary<CommandEnum, DeviceAction> _actionDictionary;
        public TCPServer(ICommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
            _actionDictionary = new Dictionary<CommandEnum, DeviceAction>() {
                {
                    CommandEnum.listDevices,
                    _commandExecuter.GetDevices
                },
                 {
                    CommandEnum.toggle,
                    _commandExecuter.ChangeState
                },
                {
                    CommandEnum.setValue,
                    _commandExecuter.SetValue
                },
            };
        }

        public void Start()
        {
            var port = 2424;
            var listener = TcpListener.Create(port);
            listener.Start();
            while (true)
            {
                var client = listener.AcceptTcpClient();
                // handle new client connection
                Task.Run(() =>
                {
                    using (var stream = client.GetStream())
                    using (var reader = new StreamReader(stream))
                    using (var writer = new StreamWriter(stream) { AutoFlush = true })
                        while (client.Connected)
                        {
                            try
                            {
                                var line = reader.ReadLine();
                                // process command

                                try
                                {
                                    string[] commandLine = line.Split(" ");
                                    CommandEnum command = (CommandEnum)Enum.Parse(typeof(CommandEnum), commandLine[0]);
                                    string response = _actionDictionary[command].Invoke(line);
                                    writer.WriteLine(response);
                                }
                                catch (Exception ex)
                                {
                                    writer.WriteLine(ex.Message);
                                }
                            }
                            catch (IOException)
                            {
                                if (client.Connected) throw;
                            }
                        }
                });
            }
        }
    }
}