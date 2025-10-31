using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.EntityConfiguration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(m => m.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.LastName).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Gender).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(250).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();

            builder.HasData(
                new Member(1, "Teste", "Uno", "masculino", "testeuno@teste.com", true),
                new Member(2, "Teste", "Dos", "feminio", "testedos@teste.com", true));
        }
    }
}
