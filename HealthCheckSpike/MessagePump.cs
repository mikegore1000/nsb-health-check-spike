using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace HealthCheckSpike
{
    public class MessagePump : IHostedService
    {
        private IEndpointInstance endpoint;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var endpointConfig = new EndpointConfiguration("HealthCheckSpike");
            endpointConfig.UseTransport<LearningTransport>();
            endpointConfig.UsePersistence<LearningPersistence>();

            endpoint = await Endpoint.Start(endpointConfig);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return endpoint.Stop();
        }
    }
}
