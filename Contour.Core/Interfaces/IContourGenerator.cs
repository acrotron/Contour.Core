using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

/// <summary>
/// Unified contour generation interface.
/// </summary>
public interface IContourGenerator
{
    /// <summary>
    /// Sets the triangles to use for contour generation.
    /// </summary>
    void SetTriangles(IList<TriExt> triangles);

    /// <summary>
    /// Generate contour lines for the specified intervals.
    /// </summary>
    Dictionary<double, List<LineString>> GenerateContourLines(double[] intervals);

    /// <summary>
    /// Generate contour polygons for the specified intervals.
    /// </summary>
    Dictionary<double, MultiPolygon> GenerateContourPolygons(double[] intervals, IProgress<OperationProgress>? progress = null);
}
