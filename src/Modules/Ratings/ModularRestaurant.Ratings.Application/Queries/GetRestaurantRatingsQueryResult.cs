using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModularRestaurant.Ratings.Application.Queries
{
    public class GetRestaurantRatingsQueryResult
    {
        public long NumberOfRatings { get; set; }

        [JsonIgnore] public long SumOfRatings { get; set; }

        public double? AverageRating => NumberOfRatings == 0 ? null : (double) SumOfRatings / NumberOfRatings;

        public List<UserRating> UserRatings { get; set; }
        
        public class UserRating
        {
            public Guid UserId { get; set; }

            public string Username { get; set; }

            public int Rating { get; set; }

            public string Comment { get; set; }

            public string RestaurantReply { get; set; }
        }
    }
}