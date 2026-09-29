using Contour.Core.Interfaces;
using NetTopologySuite.Geometries;

namespace Contour.Core;

/// <summary>
/// Geometry precision for projected (LCC/metric) coordinates.
/// Uses a floating (full double) precision model, so coordinates are not snapped to a grid.
/// </summary>
public class LccGeometryPrecision : IGeometryPrecision
{
    /// <inheritdoc />
    public GeometryFactory GeometryFactory { get; } = new GeometryFactory(new PrecisionModel(PrecisionModels.Floating));
}
