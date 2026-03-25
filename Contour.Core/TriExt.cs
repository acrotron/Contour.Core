using System.Diagnostics;
using NetTopologySuite.Geometries;
using NetTopologySuite.Triangulate.Tri;

namespace Contour.Core;

/// <summary>
/// An extended <see cref="Tri"/> class that has a unique ID and exposes the coordinates as a <see cref="CoordinateM"/> type.
/// </summary>
/// <remarks>
/// Definitions:
/// Border: A triangle that has at least one edge that is on the border of the study area.
/// Boundary: An edge of a triangle that is on the border of the study area.
/// Edge: A line between two vertices of a triangle.
/// </remarks>
[DebuggerDisplay("{Id}, 1: {P0M}, 2: {P1M}, 3: {P2M}")]
public class TriExt : Tri
{
    public TriExt(int id, CoordinateM p0, CoordinateM p1, CoordinateM p2) : base(p0, p1, p2)
    {
        Id = id;
        P0M = p0;
        P1M = p1;
        P2M = p2;

        LowestVertexValue = Math.Min(Math.Min(p0.M, p1.M), p2.M);
        HighestVertexValue = Math.Max(Math.Max(p0.M, p1.M), p2.M);
    }

    public int Id { get; }

    public CoordinateM P0M { get; set; }

    public CoordinateM P1M { get; set; }

    public CoordinateM P2M { get; set; }

    public double LowestVertexValue { get; }

    public double HighestVertexValue { get; }

    /// <summary>
    /// Returns an edge of the triangle, based on the index.
    /// </summary>
    /// <param name="index">a value from 0 to 2.</param>
    /// <returns>The two vertices of the edge.</returns>
    public TriEdge GetEdge(int index)
    {
        return index switch
        {
            0 => new TriEdge(P0M, P1M),
            1 => new TriEdge(P1M, P2M),
            2 => new TriEdge(P2M, P0M),
            _ => throw new ArgumentOutOfRangeException(nameof(index))
        };
    }

    public bool HasSharedEdge(TriEdge other)
    {
        for (int i = 0; i < 3; i++)
        {
            TriEdge edge = GetEdge(i);

            if (edge.IsEqual(other)) return true;
        }

        return false;
    }

    /// <summary>
    /// Get Adjacent triangles. These are triangles that share an edge with the current triangle.
    /// Not all edges need to have an adjacent triangle, considering a triangle can be on a border.
    /// </summary>
    public IEnumerable<TriExt> GetAdjacentTriangles()
    {
        for (int i = 0; i < 3; i++)
        {
            if (HasAdjacent(i))
            {
                TriExt? tri = (TriExt) GetAdjacent(i);

                Debug.Assert(tri != null, "tri != null");

                yield return tri;
            }
        }
    }
}