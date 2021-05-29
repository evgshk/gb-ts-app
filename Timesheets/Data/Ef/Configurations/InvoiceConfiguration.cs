using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class InvoiceConfiguration:IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("invoices");
        }
    }
}