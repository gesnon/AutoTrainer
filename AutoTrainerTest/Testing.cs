using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Respawn.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respawn;
namespace AutoTrainerTest
{
    [SetUpFixture]
    public class Testing
    {
        private static WebApplicationFactory<Program> _factory = null!;
        private static IConfiguration _configuration = null!;
        public static IServiceScopeFactory _scopeFactory = null!;
        private static Checkpoint _checkpoint = null!;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            _factory = new CustomWebApplicationFactory();
            _configuration = _factory.Services.GetRequiredService<IConfiguration>();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new Table[] { "__EFMigrationsHistory" }
            };
        }

        public static async Task ResetState()
        {
            await _checkpoint.Reset(_configuration.GetConnectionString("IwpDatabase"));
        }
    }
}
