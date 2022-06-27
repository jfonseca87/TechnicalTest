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
    public class PostTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer Server { get; }

        public PostTests()
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
        public async Task post_product_with_empty_name_should_return_bad_request()
        {
            var prod = new Product { Name = "", Weight = 150 };

            var response = await Server.CreateClient().PostAsJsonAsync("/product", prod);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task post_product_with_zero_weight_should_return_bad_request()
        {
            var prod = new Product { Name = "", Weight = 150 };

            var response = await Server.CreateClient().PostAsJsonAsync("/product", prod);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task post_valid_product_should_return_the_user_and_ok_status_code()
        {
            var prod = new Product { Name = "Smartphone", Weight = 150 };

            var response = await Server.CreateClient().PostAsJsonAsync("/product", prod);

            response.EnsureSuccessStatusCode();
            var createdProd = await response.Content.ReadAsJsonAsync<Product>();
            createdProd.ID.Should().Be(1);
            createdProd.Name.Should().Be("Smartphone");
            createdProd.Weight.Should().Be(150);
        }
    }
}
