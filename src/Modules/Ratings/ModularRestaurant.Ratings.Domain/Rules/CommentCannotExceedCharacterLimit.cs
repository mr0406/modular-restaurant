using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CommentCannotExceedCharacterLimit : IBusinessRule
    {
        private const int MaxCharacters = 500;

        public string Message => $"Comment longer than max character limit: {MaxCharacters}";

        private readonly string _text;

        public CommentCannotExceedCharacterLimit(string text)
        {
            _text = text;
        }

        public bool IsBroken() => _text.Length > MaxCharacters;
    }
}
