using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// Interpolation helpers for contouring along triangle edges.
/// </summary>
public static class Utilities
{
    /// <summary>
    /// Uses linear interpolation between two points to find the point that matches the scalar value.
    /// </summary>
    /// <returns>
    /// The interpolated point for the scalar value, with M set to the scalar value. When both points have the same
    /// M value, the midpoint of the two points is returned.
    /// </returns>
    public static CoordinateM Interpolate(CoordinateM c1, CoordinateM c2, double scalar)
    {
        double dM = c2.M - c1.M;
        if (dM == 0.0)
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
    /// Checks whether a contour level passes through an edge, i.e. exactly one of the two vertex values is above it.
    /// </summary>
    public static bool ContourPassesThroughEdge(double m1, double m2, double contourLevel)
    {
        // Contour passes through the edge if one point is above and the other is below the contour level
        return m1 > contourLevel != m2 > contourLevel;
    }
}