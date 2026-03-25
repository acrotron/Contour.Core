using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

public interface IContourLines
{
    Dictionary<double, List<LineString>> Contours(IList<TriExt> tris, double[] intervals);
}