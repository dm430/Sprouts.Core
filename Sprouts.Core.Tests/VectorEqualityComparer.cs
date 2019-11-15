using System;
using System.Collections.Generic;
using System.Numerics;

namespace Sprouts.Core.Test
{
    internal class VectorEqualityComparer : IEqualityComparer<Vector2>
    {
        public bool Equals(Vector2 vector1, Vector2 vector2)
        {
            return Math.Abs(Vector2.Distance(vector1, vector2)) <= 1e-3f;
        }

        public int GetHashCode(Vector2 obj)
        {
            throw new NotImplementedException();
        }
    }
}
