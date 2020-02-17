// Learn more about F# at http://fsharp.org

open System
open Echo

[<EntryPoint>]
let main argv =
    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
    let channelUrl = Environment.GetEnvironmentVariable("CHANNELURL")
    let channel = Grpc.Net.Client.GrpcChannel.ForAddress(channelUrl)
    let client = Echo.EchoService.EchoServiceClient(channel)
    client.Echo(EchoMessage(MessageText="Fsharp GRPC"))
    |> printfn "%A"
    0
