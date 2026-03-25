using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// struct to hold the interpolated value (CoordinateM), and the <see cref="TriEdge"/> on which the interpolate value was based upon.
/// </summary>
public readonly struct Intersection
{
    /// <summary>
    /// struct to hold the interpolated value (CoordinateM), and the <see cref="TriEdge"/> on which the interpolate value was based upon.
    /// </summary>
    public Intersection(CoordinateM interpolatedValue, TriEdge triEdge)
    {
        InterpolatedValue = interpolatedValue;
        TriEdge = triEdge;
    }

    /// <summary>
    /// Interpolated value between the two vertices of the edge that matches the specified interval when the Intersection was created.
    /// </summary>
    public CoordinateM InterpolatedValue { get; }

    /// <summary>
    /// Edge on which the InterpolatedValue is found for a specific interval.
    /// </summary>
    public TriEdge TriEdge { get; }

    public static List<Intersection> GetIntersections(double interval, TriExt triangle)
    {
        List<Intersection> intersections = [];

        // Identify where the contour level passes through the triangle's edges
        if (Utilities.ContourPassesThroughEdge(triangle.P0M.M, triangle.P1M.M, interval))
        {
            intersections.Add(
                new Intersection(
                    Utilities.Interpolate(triangle.P0M, triangle.P1M, interval),
                    new TriEdge(
                        triangle.P0M,
                        triangle.P1M
                    )));
        }

        if (Utilities.ContourPassesThroughEdge(triangle.P1M.M, triangle.P2M.M, interval))
        {
            intersections.Add(
                new Intersection(
                    Utilities.Interpolate(triangle.P1M, triangle.P2M, interval),
                    new TriEdge(
                        triangle.P1M,
                        triangle.P2M
                    )));
        }

        if (Utilities.ContourPassesThroughEdge(triangle.P2M.M, triangle.P0M.M, interval))
        {
            intersections.Add(
                new Intersection(
                    Utilities.Interpolate(triangle.P2M, triangle.P0M, interval),
                    new TriEdge(
                        triangle.P2M,
                        triangle.P0M
                    )));
        }

        return intersections;
    }
}