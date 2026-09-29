using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

/// <summary>
/// Generates contour lines from a triangle mesh.
/// </summary>
public interface IContourLines
{
    /// <summary>
    /// Generates the contour lines for each interval.
    /// </summary>
    /// <param name="tris">Triangles whose vertex M values hold the data values.</param>
    /// <param name="intervals">Contour levels.</param>
    /// <returns>The contour lines per interval.</returns>
    Dictionary<double, List<LineString>> Contours(IList<TriExt> tris, double[] intervals);
}