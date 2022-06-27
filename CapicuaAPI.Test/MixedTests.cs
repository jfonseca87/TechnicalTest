using System;
using System.Net;
using System.Threading.Tasks;
using CapicuaAPI.Model;
using CapicuaAPI.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using CapicuaAPI.Tests.Extensions;
using FluentAssertions;

namespace CapicuaAPI.Tests
{
    // Test classes should not be modified
    public class MixedTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer Server { get; }

        public MixedTests()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>());

            _context = Server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
        }

        [Fact]
        public async Task post_and_get()
        {
            // Get
            var getResponse = await Server.CreateClient().GetAsync("/product/1");
            var getProduct = await getResponse.Content.ReadAsJsonAsync<Product>();
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);

            // Post
            var prod = new Product { Name = "Smartphone", Weight = 150 };
            var response = await Server.CreateClient().PostAsJsonAsync("/product", prod);
            response.EnsureSuccessStatusCode();


            var getResponse2 = await Server.CreateClient().GetAsync("/product/1");
            var newProduct = await getResponse2.Content.ReadAsJsonAsync<Product>();
            getResponse2.EnsureSuccessStatusCode();

            newProduct.ID.Should().Be(1);
            newProduct.Name.Should().Be(prod.Name);
            newProduct.Weight.Should().Be(prod.Weight);
        }
    }
}
