using endterm.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace endterm.Database.Configurations;

public class PostConfiguration
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id);
        builder.Property(p => p.UserId);
        builder.Property(p => p.Title);
        builder.Property(p => p.Text);
        builder.Property(p => p.CreatedAt);
    }
}