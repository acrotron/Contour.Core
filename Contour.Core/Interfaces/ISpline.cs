using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

public interface ISpline
{
    /// <summary>
    /// Interpolates scattered WGS84 points onto a regular LCC grid.
    /// Input points are in WGS84 (lon, lat, M). Output grid is in LCC (easting, northing, M).
    /// </summary>
    CoordinateM[,] InterpolateToGrid(List<CoordinateM> points, double airportLatitude, double airportLongitude);
}