using Microsoft.Extensions.Hosting;

namespace LDAPProxy.Proxy;

public class ProxyService(LdapServer server) : IHostedService
{
    
    public Task StartAsync(CancellationToken token)
    {
        server.Start();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken token)
    {
        server.Stop();
        return Task.CompletedTask;
    }
}