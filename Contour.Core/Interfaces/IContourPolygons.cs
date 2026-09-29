using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

/// <summary>
/// Generates contour polygons from a triangle mesh.
/// </summary>
public interface IContourPolygons
{
    /// <summary>
    /// Generates the contour polygons for each interval.
    /// </summary>
    /// <param name="tris">Triangles whose vertex M values hold the data values.</param>
    /// <param name="intervals">Contour levels.</param>
    /// <param name="progress">Optional progress reporting.</param>
    /// <returns>The contour polygons per interval.</returns>
    Dictionary<double, MultiPolygon> Contours(IList<TriExt> tris, double[] intervals, IProgress<OperationProgress>? progress = null);
}