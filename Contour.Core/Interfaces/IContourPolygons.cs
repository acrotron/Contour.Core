using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

public interface IContourPolygons
{
    Dictionary<double, MultiPolygon> Contours(IList<TriExt> tris, double[] intervals, IProgress<OperationProgress>? progress = null);
}