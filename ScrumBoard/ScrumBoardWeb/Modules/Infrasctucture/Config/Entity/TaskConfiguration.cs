namespace ScrumBoardWeb.Modules.Infrasctucture.Config;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumBoardWeb.Modules.Infrasctucture.Entity;
public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .ToTable("task")
            .HasKey(t => t.Id);

        builder
            .Property(c => c.Title)
            .IsRequired()
            .HasColumnType("VARCHAR(255)");

        builder
            .Property(c => c.Description)
            .IsRequired()
            .HasColumnType("TEXT");

        builder
            .Property(c => c.Priority)
            .IsRequired();
    }
}
