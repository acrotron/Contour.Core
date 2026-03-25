using NetTopologySuite.Geometries;

namespace Contour.Core;

public static class Utilities
{
    /// <summary>
    /// Uses linear interpolation between two points to find the point that matches the scalar value.
    /// </summary>
    /// <returns>
    /// the interpolated point for the scalar value or an invalid CoordinateM object with invalid X, Y values (NaN and/or -Infinity) if the scalar value can't be determined.
    /// </returns>
    public static CoordinateM Interpolate(CoordinateM c1, CoordinateM c2, double scalar)
    {
        double dM = c2.M - c1.M;
        if (Math.Abs(dM) < double.Epsilon)
        {
            // Both endpoints have the same M value; return the midpoint
            return new CoordinateM((c1.X + c2.X) / 2, (c1.Y + c2.Y) / 2, scalar);
        }

        // Perform linear interpolation between p1 and p2 to find the intersection point
        double m = (scalar - c1.M) / dM;

        double x = c1.X + m * (c2.X - c1.X);
        double y = c1.Y + m * (c2.Y - c1.Y);

        return new CoordinateM(x, y, scalar);
    }

    /// <summary>
    /// method to check if a contour passes through an edge of a triangle
    /// </summary>
    public static bool ContourPassesThroughEdge(double m1, double m2, double contourLevel)
    {
        // Contour passes through the edge if one point is above and the other is below the contour level
        return m1 > contourLevel != m2 > contourLevel;
    }
}