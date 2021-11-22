﻿using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using StayNet.Common.Enums;
using StayNet.Server.Entities;

namespace StayNet.Server
{
    public class Client
    {

        public int Id { get; internal set; }
        
        internal TcpClient TcpClient;
        public StayNetServer Server { get; internal set; }
        
        internal Client(TcpClient tcpclient, StayNetServer server)
        {
            this.TcpClient = tcpclient;
            this.Server = server;
            this.Id = this.TcpClient.Client.Handle.ToInt32();
            while (server.m_clients.ContainsKey(this.Id))
            {
                this.Id++;
            }
        }

        /**
         * Wait for the client to send Initial Connection packet. Usually containing things like authorization, etc.
         */
        internal async Task<ClientConnectionData> WaitForConnectionData()
        {
            var stream = TcpClient.GetStream();
            //we need to wait for the client to send us the initial connection data
            while (!stream.DataAvailable)
            {
                await Task.Delay(50);
            }
            var data = new byte[TcpClient.Available];
            await stream.ReadAsync(data, 0, data.Length);
            var connectionData = new ClientConnectionData();
            var id = data[0];

            // if the id doesnt match the InitialMessage packet id, we need to disconnect the client. In this case, we just return null 
            // and the client will be disconnected.
            if (id != (int) BasePacketTypes.InitialMessage)
            {
                this.Server.Log(LogLevel.Debug, $"Client {this.Id} sent invalid id {id.ToString("X")}");
                return null;
            }
            // if the id is correct, we need to read the rest of the data, but if the data is too big, we need to disconnect the client.
            if (data.Length > 256)
            {
                // In this case, we just return null and the client will be disconnected.
                this.Server.Log(LogLevel.Debug, $"Client {this.Id} initial data too large {data.Length}");
                return null;
            }
            // if the data is correct, we need to read the rest of the data.
            var dlist = data.ToList();
            // remove the id
            dlist.RemoveAt(0);
            // convert the list to a byte array and set the connection data
            connectionData.Stream = new MemoryStream(dlist.ToArray());
            
            return connectionData;
        }
        
        internal async Task EndInitialization()
        {
            //TODO: Implement this
            throw new NotImplementedException();
        }

        internal void Close()
        {
            TcpClient.Close();
        }
        
    }
}