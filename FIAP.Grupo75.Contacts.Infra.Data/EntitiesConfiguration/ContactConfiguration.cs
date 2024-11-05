using FIAP.Grupo75.Contacts.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.Grupo75.Contacts.Infra.Data.EntitiesConfiguration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(250).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(15).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.CreatedDate).IsRequired();

            builder.HasOne(c => c.Ddd).WithMany(c => c.Contacts)
                .HasForeignKey(c => c.DddId);
        }
    }
}
