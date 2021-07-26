using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication1;
using Xunit;

namespace TestProject1
{
    public class StatusMiddlewareTests
    {
        [Fact]
        public async Task StatusMiddlwareReturnPong()
        {
            var hostBuilder = new WebHostBuilder()
                .Configure(app =>
                {
                    app.UseMiddleware<StatusMiddleware>();
                });

            using (var server = new TestServer(hostBuilder))
            {
                HttpClient client = server.CreateClient();
                var response = await client.GetAsync("/ping");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                Assert.Equal("pong", content);
            }
        }
    }
}