using System;
using System.Collections.Generic;
using System.Numerics;

namespace Sprouts.Core.Test.Geometry
{
    public class CatmullRomSpline
    {
        private const int MinimumNumberOfControlPoints = 4;
        private const int ControlPointOffset = MinimumNumberOfControlPoints - 1;
        private const float ControlPointDistanceMax = 1f;

        private readonly IList<Vector2> controlPoints;

        public CatmullRomSpline(IList<Vector2> controlPoints)
        {
            if (controlPoints == null)
            {
                throw new ArgumentNullException(nameof(controlPoints));
            }

            if (controlPoints.Count < MinimumNumberOfControlPoints)
            {
                throw new ArgumentOutOfRangeException(nameof(controlPoints), "There must be at least 4 control point supplied to the spline.");
            }

            this.controlPoints = controlPoints;
        }

        public int SegmentCount => controlPoints.Count - ControlPointOffset;

        public IEnumerable<Vector2> InterpolatePoints(int numberOfPointsInSegment)
        {
            var allPointsInSpline = new List<Vector2>();

            for (var index = 0; index < controlPoints.Count - ControlPointOffset; index++) {
                var pointsInSegment = CalculatePointsInSegment(controlPoints[index], controlPoints[index + 1], controlPoints[index + 2], controlPoints[index + 3], numberOfPointsInSegment);

                allPointsInSpline.AddRange(pointsInSegment);
            }

            return allPointsInSpline;
        }

        protected IEnumerable<Vector2> CalculatePointsInSegment(Vector2 point0, Vector2 point1, Vector2 point2, Vector2 point3, float numberOfPointsInSegment)
        {
            var pointsInSegment = new List<Vector2>();
            var resolution = ControlPointDistanceMax / numberOfPointsInSegment;
            
            for (var resolutionStep = resolution; resolutionStep < ControlPointDistanceMax; resolutionStep += resolution)
            {
                var pointOnCurve = CalculatePointOnCurve(point0, point1, point2, point3, resolutionStep);

                pointsInSegment.Add(pointOnCurve);
            }

            return pointsInSegment;
        }

        protected static Vector2 CalculatePointOnCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            var t2 = t * t;
            var t3 = t2 * t;

            var x = 0.5f * ((2.0f * p1.X) +
                (-p0.X + p2.X) * t +
                (2.0f * p0.X - 5.0f * p1.X + 4 * p2.X - p3.X) * t2 +
                (-p0.X + 3.0f * p1.X - 3.0f * p2.X + p3.X) * t3);

            var y = 0.5f * ((2.0f * p1.Y) +
                (-p0.Y + p2.Y) * t +
                (2.0f * p0.Y - 5.0f * p1.Y + 4 * p2.Y - p3.Y) * t2 +
                (-p0.Y + 3.0f * p1.Y - 3.0f * p2.Y + p3.Y) * t3);

            return new Vector2(x, y);
        }
    }
}
