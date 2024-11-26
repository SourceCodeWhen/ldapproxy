using System.Net;
using LDAPProxy.Proxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IPEndPoint>(x =>
{
    var hostName = Dns.GetHostName();
    IPHostEntry localhost = Dns.GetHostEntry(hostName);
    return new IPEndPoint(localhost.AddressList[0], 38999);
});
builder.Services.AddSingleton<LdapServer>();
builder.Services.AddHostedService<ProxyService>();

IHost host = builder.Build();
host.Run();