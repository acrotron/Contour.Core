using Contour.Core.Interfaces;
using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// Geometry precision for projected (LCC/metric) coordinates.
/// PrecisionModel(1000) gives millimeter precision in meters.
/// </summary>
public class LccGeometryPrecision : IGeometryPrecision
{
    public GeometryFactory GeometryFactory { get; } = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating));
}
