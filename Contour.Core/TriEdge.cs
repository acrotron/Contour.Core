using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// Represents a triangle edge.
/// </summary>
/// <param name="start">start vertex.</param>
/// <param name="end">end vertex.</param>
public readonly struct TriEdge(CoordinateM start, CoordinateM end)
{
    /// <summary>
    /// Start vertex.
    /// </summary>
    public CoordinateM Start { get; } = start;

    /// <summary>
    /// End vertex.
    /// </summary>
    public CoordinateM End { get; } = end;

    /// <summary>
    /// Returns true when both edges have the same two vertices (compared in 2D), in either direction.
    /// </summary>
    public bool IsEqual(TriEdge other)
    {
        return (Start.Equals2D(other.Start) && End.Equals2D(other.End)) ||
               (End.Equals2D(other.Start) && Start.Equals2D(other.End));

    }
}