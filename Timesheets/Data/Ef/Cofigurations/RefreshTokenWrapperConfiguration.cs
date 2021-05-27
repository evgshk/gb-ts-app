using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Ef.Cofigurations
{
    public class RefreshTokenWrapperConfiguration : IEntityTypeConfiguration<RefreshTokenWrapper>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenWrapper> builder)
        {
            builder.ToTable("refreshtokenwrappers");
        }
    }
}
