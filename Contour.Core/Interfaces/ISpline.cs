using NetTopologySuite.Geometries;

namespace Contour.Core.Interfaces;

public interface ISpline
{
    /// <summary>
    /// Interpolates scattered WGS84 points onto a regular grid using LCC projection.
    /// </summary>
    CoordinateM[,] InterpolateToGrid(List<CoordinateM> points, double airportLatitude, double airportLongitude);
}