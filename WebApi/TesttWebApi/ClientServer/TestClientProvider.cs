using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using WebApi;
using Xunit;

namespace TestWebApi.Provider
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;

        public TestClientProvider()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseSetting("DatabaseSettings:ConnectionString", "Data Source=DESKTOP-9R0JJCE\\SQLEXPRESS;Initial Catalog=SmartAssembly;Integrated Security=True");
            
            server = new TestServer(builder);
            Client = server.CreateClient();
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
