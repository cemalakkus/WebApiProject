using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiProject.Domain.Entities;

namespace WebApiProject.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category1 = new()
            {
                Id = 1,
                Name = "Elektronik",
                ParentId = 0,
                Priority = 1,
            };

            Category category2 = new()
            {
                Id = 2,
                Name = "Moda",
                ParentId = 0,
                Priority = 2,
            };

            Category parent1 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                ParentId = 1,
                Priority = 1,
            };

            Category parent2 = new()
            {
                Id = 4,
                Name = "KAdın",
                ParentId = 2,
                Priority = 1,
            };

            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
