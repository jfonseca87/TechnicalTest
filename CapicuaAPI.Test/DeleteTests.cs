using System;
using System.Net;
using System.Threading.Tasks;
using CapicuaAPI.Model;
using CapicuaAPI.Database;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;

namespace CapicuaAPI.Tests
{
    // Test classes should not be modified
    public class DeleteTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer Server { get; }

        public DeleteTests()
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
        public async Task delete_product_with_id_3_should_return_not_found_status_code()
        {
            var response = await Server.CreateClient().DeleteAsync("/product/3");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task delete_product_with_id_2_should_be_successful()
        {
            // Setup
            _context.Products.AddRange(
                 new Product { Name = "Hat", Weight = 45 },
                 new Product { Name = "Table", Weight = 1000 },
                 new Product { Name = "Chair", Weight = 730 }
            );
            await _context.SaveChangesAsync();

            // Delete
            var response = await Server.CreateClient().DeleteAsync("/product/2");
            response.EnsureSuccessStatusCode();

            // Get
            var getResponse = await Server.CreateClient().GetAsync("/product/2");
            getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
