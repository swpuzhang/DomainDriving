using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;
            if (ReferenceEquals(compareTo, this))
                return true;
            if (compareTo == null)
            {
                return false;
            }
            return Id.Equals(compareTo.Id);
        }
        public static bool operator == (Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]"; 
        }

        /// <summary>
        /// 获取哈希
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetType().GetHashCode()  + Id.GetHashCode();
        }
    }
}
