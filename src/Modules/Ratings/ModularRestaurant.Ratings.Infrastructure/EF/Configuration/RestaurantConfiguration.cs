using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasConversion(id => id.Value, id => new RestaurantId(id));

            builder.OwnsMany(x => x.UserRatings, x =>
            {
                x.OwnsOne(x => x.UserId, y => { y.Property(a => a.Value).HasColumnName("UserId"); });
                x.OwnsOne(x => x.Rating, y => { y.Property(a => a.Value).HasColumnName("Rating"); });
            });
        }
    }
}