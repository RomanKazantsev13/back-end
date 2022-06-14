namespace ScrumBoardWeb.Modules.Infrasctucture.Config;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScrumBoardWeb.Modules.Infrasctucture.Entity;

public class ColumnConfiguration : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder
            .ToTable("column")
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Title)
            .IsRequired()
            .HasColumnType("VARCHAR(255)");
    }
}

