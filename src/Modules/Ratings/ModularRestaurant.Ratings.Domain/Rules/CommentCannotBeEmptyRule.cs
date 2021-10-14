using ModularRestaurant.Shared.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Ratings.Domain.Rules
{
    public class CommentCannotBeEmptyRule : IBusinessRule
    {
        public string Message => "Comment cannot ce empty.";

        private readonly string _text;

        public CommentCannotBeEmptyRule(string text)
        {
            _text = text;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_text);
    }
}
