using Contour.Core.Interfaces;
using NetTopologySuite.Geometries;

namespace Contour.Core;

public class Wgs84GeometryPrecision : IGeometryPrecision
{
    public GeometryFactory GeometryFactory { get; } = new GeometryFactory(new PrecisionModel(1000));
}