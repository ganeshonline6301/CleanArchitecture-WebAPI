using CleanArch.Domain.Todos;
using CleanArch.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Users;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(25);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany<Todo>()
            .WithOne()
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(
            new User("Ganesh Penke", "john.doe@example.com", new Guid("11111111-1111-1111-1111-111111111111")),
            new User("Uncle Bob", "jane.smith@example.com", new Guid("22222222-2222-2222-2222-222222222222"))
        );
    }
}