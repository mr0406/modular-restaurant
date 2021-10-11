using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Shared.Domain.Types
{
    public abstract class TypeId : IEquatable<TypeId>
    {
        public Guid Value { get; }

        protected TypeId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidOperationException("Id value cannot be empty!");
            }

            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TypeId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(TypeId other)
        {
            return this.Value == other?.Value;
        }

        public static bool operator ==(TypeId obj1, TypeId obj2)
        {
            if (object.Equals(obj1, null))
            {
                if (object.Equals(obj2, null))
                {
                    return true;
                }

                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(TypeId x, TypeId y)
        {
            return !(x == y);
        }
    }
}
