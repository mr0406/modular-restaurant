using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ModularRestaurant.Ratings.Application.DTOs
{
    public class RestaurantDTO
    {
        public Guid Id { get; set; }

        public long NumberOfRatings { get; set; }

        [JsonIgnore] public long SumOfRatings { get; set; }

        public double? AverageRating => NumberOfRatings == 0 ? null : (double) SumOfRatings / NumberOfRatings;

        public List<UserRatingDTO> UserRatings { get; set; }
    }

    public class UserRatingDTO
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }

        //userPhoto

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string RestaurantReply { get; set; }
    }
}