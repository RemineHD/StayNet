
global using System;
using System.Threading;
using ExampleConsoleApp;
using StayNet;
using StayNet.Server.Controllers;

Console.WriteLine("Hello World!");
SimpleServerExample.Run();
Thread.Sleep(1000);
SimpleClientExample.Run();
while (true) ;
/*
 *
 * THIS PROGRAM DOESNT REALLY DO ANYTHING. BUT YOU CAN CHECK THE EXAMPLES. 
 * 
*/

