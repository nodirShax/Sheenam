//===========================================================
//CopyRight (c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//===========================================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext , IStorageBroker
    {
        private readonly IConfiguration _configuration;
        public StorageBroker(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = 
                _configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }

        public override void Dispose() { }
    }
}
