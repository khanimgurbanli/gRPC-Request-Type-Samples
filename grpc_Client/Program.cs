using Grpc.Net.Client;
using grpc_MessageClient;

CancellationTokenSource cancellationToken = new();
var channel = GrpcChannel.ForAddress("http://localhost:5111");
var messageClient = new Message.MessageClient(channel);


/*
------ DEFAULT TEMPLATE --------

var greetClientr=new Greeter.GreeterClient(channel);
HelloReply reply=await greetClientr.SayHelloAsync(new HelloRequest{
Name="Hello request from GrpcSerivce"

System.Console.WriteLine(messageResponse.Message);
});
*/

/* 
-------- UNARY TYPE EXAMPLE ---------
When Client  one request to Server  and server return just one response

var messageClient = new Message.MessageClient(channel);

MessageResponse messageResponse = await messageClient.SendAsync(new MessageRequest
{
    Message = "Hello",
    Name = "Khanim"
}); 


/*
-------- SERVER STREAMING TYPE EXAMPLE ---------
When Client  one request to Server  and server return stream response

var messageClient = new Message.MessageClient(channel);
var messageResponse = messageClient.Send(new MessageRequest
{
    Message = "Hello",
    Name = "Khanim"
});


while (await messageResponse.ResponseStream.MoveNext(cancellationToken.Token))
{
    System.Console.WriteLine(messageResponse.ResponseStream.Current.Message);
}
*/

/*
-------- CLIENT STREAMING TYPE EXAMPLE ---------
When Client  stream request to Server  and server return one response

var messageClient = new Message.MessageClient(channel);

var request = messageClient.Send();

for (int i = 0; i <= 10; i++)
{
    await Task.Delay(100);
    await request.RequestStream.WriteAsync(new MessageRequest()
    {
        Name = "Khanim",
        Message = "Hello, how are you"
    });
}

await request.RequestStream.CompleteAsync();
System.Console.WriteLine((await request.ResponseAsync).Message);

*/


/*
-------- BI DIRECTIONAL STREAMING TYPE EXAMPLE ---------
When Client  stream request to Server  and server return stream response

var request = messageClient.Send();

var  firstTask= Task.Run(async () =>
{
    for (int i = 0; i <= 10; i++)
    {
        await Task.Delay(1000);
        await request.RequestStream.WriteAsync(new MessageRequest()
        {
            Name = "Khanim",
            Message = "Hello, how are you"
        });
    }
});

while(await request.ResponseStream.MoveNext(cancellationToken.Token)){

 System.Console.WriteLine(request.ResponseStream.Current.Message);
}
await firstTask;
await request.RequestStream.CompleteAsync();

*/