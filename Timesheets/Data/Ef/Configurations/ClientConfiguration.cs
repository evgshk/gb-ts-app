using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;

namespace Timesheets.Data.Ef.Configurations
{
    public class ClientConfiguration: IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");
        }
    }
}