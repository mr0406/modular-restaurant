using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModularRestaurant.Ratings.Domain.Entities;
using ModularRestaurant.Shared.Domain.Types;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Configuration
{
    public class UserRatingConfiguration : IEntityTypeConfiguration<UserRating>
    {
        public void Configure(EntityTypeBuilder<UserRating> builder)
        {
            builder.HasKey(userRating => userRating.Id);
            
            builder.Property(userRating => userRating.Id)
                .HasConversion(id => id.Value, id => new UserRatingId(id));
            
            builder.Property(userRating => userRating.RestaurantId)
                .HasConversion(restaurantId => restaurantId.Value, restaurantId => new RestaurantId(restaurantId));
            
            builder.Property(userRating => userRating.UserId)
                .HasConversion(userId => userId.Value, userId => new UserId(userId));

            builder.OwnsOne(userRating => userRating.Rating, r =>
            {
                r.Property(rating => rating.Value).HasColumnName("Value");
            });
        }
    }
}