using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public virtual T Clone()
        {
            return (T)MemberwiseClone();
        }
    }
}
