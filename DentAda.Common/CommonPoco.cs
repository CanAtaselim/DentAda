using System;
using System.Collections.Generic;
using System.Text;

namespace DentAda.Common
{
    class CommonPoco : IEqualityComparer<Nullable<long>>
    {
        public bool Equals(long? x, long? y)
        {
            return x == y;
        }

        public int GetHashCode(long? obj)
        {
            throw new NotImplementedException();
        }
    }
}
