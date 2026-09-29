using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

/// <summary>
/// Supplies the geometry factory (and with it the precision model) used to create contour geometries.
/// </summary>
public interface IGeometryPrecision
{
    /// <summary>
    /// Factory used to create contour geometries.
    /// </summary>
    public GeometryFactory GeometryFactory { get; }
}
