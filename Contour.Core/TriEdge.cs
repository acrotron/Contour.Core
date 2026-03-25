using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// Represents a triangle edge.
/// </summary>
/// <param name="start">start vertex.</param>
/// <param name="end">end vertex.</param>
public readonly struct TriEdge(CoordinateM start, CoordinateM end)
{
    public CoordinateM Start { get; } = start;
    public CoordinateM End { get; } = end;

    public bool IsEqual(TriEdge other)
    {
        return (Start.Equals2D(other.Start) && End.Equals2D(other.End)) ||
               (End.Equals2D(other.Start) && Start.Equals2D(other.End));

    }
}