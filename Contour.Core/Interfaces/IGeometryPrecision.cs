using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

public interface IGeometryPrecision
{
    public GeometryFactory GeometryFactory { get; }
}
