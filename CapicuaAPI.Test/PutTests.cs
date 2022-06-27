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
    public class PutTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private TestServer Server { get; }

        public PutTests()
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
        public async Task put_product_with_id_3_should_return_not_found_status_code()
        {
            var prod = new Product { Name = "Watch", Weight = 35 };

            var response = await Server.CreateClient().PutAsJsonAsync("/product/3", prod);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task put_product_with_id_3_should_be_successful()
        {
            // Setup
            _context.Products.AddRange(
                 new Product { Name = "Hat", Weight = 45 },
                 new Product { Name = "Table", Weight = 1000 },
                 new Product { Name = "Chair", Weight = 730 }
            );
            await _context.SaveChangesAsync();

            // Update
            var product = new Product { Name = "Watch", Weight = 35 };
            var response = await Server.CreateClient().PutAsJsonAsync("/product/3", product);
            response.EnsureSuccessStatusCode();

            // Get
            var getResponse = await Server.CreateClient().GetAsync("/product/3");
            var newProduct = await getResponse.Content.ReadAsJsonAsync<Product>();
            newProduct.ID.Should().Be(3);
            newProduct.Name.Should().Be(product.Name);
            newProduct.Weight.Should().Be(product.Weight);
        }

        [Fact]
        public async Task put_product_with_empty_name()
        {
            // Setup
            _context.Products.Add(
                 new Product { Name = "Hat", Weight = 45 }
            );
            await _context.SaveChangesAsync();

            // Update
            var product = new Product { Name = "", Weight = 35 };
            var response = await Server.CreateClient().PutAsJsonAsync("/product/1", product);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task put_product_with_negative_weight()
        {
            // Setup
            _context.Products.Add(
                 new Product { Name = "Hat", Weight = 45 }
            );
            await _context.SaveChangesAsync();

            // Update
            var product = new Product { Name = "Watch", Weight = -1 };
            var response = await Server.CreateClient().PutAsJsonAsync("/product/1", product);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
