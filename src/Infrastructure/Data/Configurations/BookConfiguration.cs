using BookLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookLibrary.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(e => e.Title).IsRequired()
            .HasMaxLength(100)
            .HasColumnName("title");

        builder.Property(e => e.FirstName).IsRequired()
            .HasMaxLength(50)
            .HasColumnName("first_name");

        builder.Property(e => e.LastName).IsRequired()
            .HasMaxLength(50)
            .HasColumnName("last_name");

        builder.Property(e => e.TotalCopies).IsRequired()
            .HasColumnName("total_copies")
            .HasDefaultValue(0); // Sets the default value

        builder.Property(e => e.CopiesInUse).IsRequired()
            .HasColumnName("copies_in_use")
            .HasDefaultValue(0); // Sets the default value

        builder.Property(e => e.Type)
            .HasMaxLength(50)
            .HasColumnName("type");

        builder.Property(e => e.Isbn)
            .HasMaxLength(80)
            .HasColumnName("isbn");

        builder.Property(e => e.Category)
            .HasMaxLength(50)
            .HasColumnName("category");
    }
}
