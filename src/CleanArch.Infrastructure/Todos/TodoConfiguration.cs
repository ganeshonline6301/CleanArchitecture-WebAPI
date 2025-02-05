using CleanArch.Domain.Todos;
using CleanArch.Domain.Todos.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Todos;

internal class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(t => t.Priority)
            .HasConversion(
                priority => priority.Value,
                value => TodoPriority.FromValue(value));
        
        builder.Property(t => t.Status)
            .HasConversion(
                status => status.Value,
                value => TodoStatus.FromValue(value));
        
        builder.Property(t => t.DueDate)
            .IsRequired();
        
        builder.Property(t => t.UserId)
            .IsRequired();
        
    }
}