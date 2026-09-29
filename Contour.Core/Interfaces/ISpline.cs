using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

/// <summary>
/// Interpolates scattered points onto a regular grid.
/// </summary>
public interface ISpline
{
    /// <summary>
    /// Interpolates scattered WGS84 points onto a regular LCC grid.
    /// Input points are in WGS84 (lon, lat, M). Output grid is in LCC (easting, northing, M).
    /// </summary>
    CoordinateM[,] InterpolateToGrid(List<CoordinateM> points, double airportLatitude, double airportLongitude);
}