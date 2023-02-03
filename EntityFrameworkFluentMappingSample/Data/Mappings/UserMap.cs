using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFluentMappingSample.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Table
            builder.ToTable("User");

            // Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            // Ìndices
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();
        }
    }
}
