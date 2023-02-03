using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EntityFrameworkFluentMappingSample.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Table
            builder.ToTable("Post");

            // Key
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // properties
            builder.Property(x => x.LastUpdateDate)
                .HasColumnType("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); // Vai gerar a data pelo Banco
                //.HasDefaultValue(DateTime.Now.ToUniversalTime()); // Vai gerar a data pelo código

            builder.HasIndex(x => x.Slug)
                .IsUnique() ;

            // Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
