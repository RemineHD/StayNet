
global using System;
using StayNet;
using StayNet.Server.Controllers;

StayNetServer server = new StayNetServer(new StayNetServerConfiguration
{
    Host = "hey!",
    Port = 8080,
});

server.RegisterController<Test>();
public class Test : BaseController
{
    
}