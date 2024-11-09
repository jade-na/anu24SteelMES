// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Hello;

Channel channel = new Channel("192.168.0.85:50051", ChannelCredentials.Insecure);
var client = new Greeter.GreeterClient(channel);
string user = "C# Client";

//var reply = client.ReqRemoteCommand(new RcmdRequest{ Command = "컨베이어야 돌아라", Param = "빨리"});
//Console.WriteLine("Rcmd Ack is " + reply.Ack);

var reply = client.SayHello(new HelloRequest{ Name = user});
Console.WriteLine("SayHello Reply " + reply.Message);

channel.ShutdownAsync().Wait();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
