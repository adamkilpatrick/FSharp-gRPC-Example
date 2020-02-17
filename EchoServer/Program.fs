open System
open Echo


type EchoServer() =
    inherit EchoService.EchoServiceBase()
    override _.Echo(message, context) =
        async {
            let reply = EchoReply(MessageResponse="Hello "+message.MessageText)
            return reply
        }
        |> Async.StartAsTask

[<EntryPoint>]
let main argv =
    let portEnv = Environment.GetEnvironmentVariable("PORT")
    let port = int(if String.IsNullOrEmpty(portEnv) then "5000" else portEnv )
    let server = Grpc.Core.Server()
    server.Services.Add(EchoService.BindService(EchoServer()))
    server.Ports.Add("0.0.0.0",port, Grpc.Core.ServerCredentials.Insecure) |> ignore
    
    server.Start()
    printfn "Server listening on port %d" port

    Async.Sleep(-1)
    |> Async.RunSynchronously
    0
