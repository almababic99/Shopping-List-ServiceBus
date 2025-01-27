using System.Net;
using NServiceBus;
class Program
{
    static async Task Main(string[] args)
    {
        Console.Title = "ServiceBus";

        var endpointConfiguration = new EndpointConfiguration("ServiceBus");

        var transport = endpointConfiguration.UseTransport<LearningTransport>();

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

        Console.WriteLine("Press Enter to exit");
        Console.ReadLine();

        await endpointInstance.Stop().ConfigureAwait(false);
    }
}
