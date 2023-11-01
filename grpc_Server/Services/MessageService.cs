using Grpc.Core;
using grpc_MessageServer;
using grpc_Server;

namespace grpc_Server;

public class MessageService : Message.MessageBase
{
    /* -------- UNARY TYPE EXAMPLE ---------
    
     public override async Task<MessageResponse> Send(MessageRequest request, ServerCallContext context)
     {  
         System.Console.WriteLine($"Message: {request.Message}  Name:{request.Name}");
         return new MessageResponse(){
             Message="Success!"
         };
     }
  */

    /* -------- SERVER STREAMING TYPE EXAMPLE ---------

     public override async Task Send(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
     {
         System.Console.WriteLine($"Message: {request.Message}  Name:{request.Name}");

         for (int i = 0; i <= 10; i++)
         {
             await Task.Delay(100);
             await responseStream.WriteAsync(new MessageResponse
             {
                 Message = "Success!"
             });
         }
     }
     */

    /*
     -------- CLIENT STREAMING TYPE EXAMPLE ---------

        public override async Task<MessageResponse> Send(IAsyncStreamReader<MessageRequest> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                System.Console.WriteLine($"Message: {requestStream.Current.Message}  Name:{requestStream.Current.Name}");
            }

            return new MessageResponse
            {
                Message = "Success!"
            };
        }
    }
    */

    /*
     -------- BI DIRECTIONAL STREAMING TYPE EXAMPLE ---------

    public override async Task Send(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        var firstTask= Task.Run(async () =>
        {
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                System.Console.WriteLine($"Message: {requestStream.Current.Message}  Name:{requestStream.Current.Name}");
            }
        });

        for (int i = 0; i <= 10; i++)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(new MessageResponse() { Message = "Message: " + 1 });
        };

        await firstTask;
    }
    */
}


