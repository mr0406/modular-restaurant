using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Types;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Menus.Infrastructure.EF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasConversion(id => id.Value, id => new MenuId(id));

            builder.Property(m => m.RestaurantId)
                .HasConversion(rId => rId.Value, rId => new RestaurantId(rId));

            builder.OwnsMany(x => x.Groups, x =>
            {
                x.ToTable("Groups").OwnsMany(a => a.Items, a =>
                {
                    a.ToTable("Items");
                    a.HasKey(a => a.Id);
                    a.Property(a => a.Id)
                        .HasConversion(id => id.Value, id => new ItemId(id));
                    a.OwnsOne(a => a.Price, p =>
                    {
                        p.Property(p => p.Value).HasColumnName("PriceValue");
                        p.Property(p => p.Currency).HasColumnName("PriceCurrency");
                    });
                }); 
                x.HasKey(x => x.Id);
                x.Property(x => x.Id)
                    .HasConversion(id => id.Value, id => new GroupId(id));
            });
        }
    }
}