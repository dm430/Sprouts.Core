using Sprouts.Core.Test.Geometry;
using System.Numerics;
using Xunit;

namespace Sprouts.Core.Test
{
    public class CatmullSplineTests
    {
        // TODO: Add more test cases.

        [Fact]
        public void SplineGeneratesAllPoints()
        {
            var spline = new CatmullRomSpline(new[] { new Vector2(0, 0), new Vector2(0, 10), new Vector2(10, 10), new Vector2(10, 0) });
            var expected = new[] { new Vector2(0.64f, 10.45f), new Vector2(1.52f, 10.8f), new Vector2(2.58f, 11.05f), new Vector2(3.76f, 11.2f), new Vector2(5, 11.25f), new Vector2(6.239999f, 11.2f), new Vector2(7.420001f, 11.05f), new Vector2(8.480001f, 10.8f), new Vector2(9.360002f, 10.45f) };
            var points = spline.InterpolatePoints(10);
          
            Assert.Equal(expected, points, new VectorEqualityComparer());
        }

        [Fact]
        public void SplineHasTheCorrectAmountOfSegments()
        {
            var spline = new CatmullRomSpline(new[] { new Vector2(0, 0), new Vector2(0, 10), new Vector2(10, 10), new Vector2(10, 0) });

            Assert.Equal(1, spline.SegmentCount);
        }
    }
}
