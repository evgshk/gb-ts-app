using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Ef.Configurations
{
    public class SheetConfiguration: IEntityTypeConfiguration<Sheet>
    {
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            builder.ToTable("sheets");

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder
                .HasOne(sheet => sheet.Invoice)
                .WithMany(invoice => invoice.Sheets)
                .HasForeignKey("InvoiceId");

            builder
                .HasOne(sheet => sheet.Contract)
                .WithMany(contract => contract.Sheets)
                .HasForeignKey("ContractId");
            
            builder
                .HasOne(sheet => sheet.Service)
                .WithMany(service => service.Sheets)
                .HasForeignKey("ServiceId");
            
            builder
                .HasOne(sheet => sheet.Employee)
                .WithMany(employee => employee.Sheets)
                .HasForeignKey("EmployeeId");
        }
    }
}