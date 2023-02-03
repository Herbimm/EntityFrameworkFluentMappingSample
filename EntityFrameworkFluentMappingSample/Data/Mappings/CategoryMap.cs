using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFluentMappingSample.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabela
            builder.ToTable("Category");

            //Chave primária
            builder.HasKey(c => c.Id);
            
            //Identity
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // Primary Key ( 1 , 1 )

            //Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // Índices
            builder.HasIndex(c => c.Slug, "IX_Category_Slug")
                .IsUnique(); // Não permite criar duas categorias com o mesmo Slug

        }
    }
}
