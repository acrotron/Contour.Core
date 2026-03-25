namespace Contour.Core;

/// <summary>
/// Lambert Conformal Conic projection matching the AEDT/Esri "Custom_Lambert_Conformal_Conic"
/// projection used by the Python MakeContours script.
/// Both standard parallels are set to the latitude of origin (tangential case).
/// Central meridian is the airport longitude, latitude of origin is the airport latitude.
/// WGS84 ellipsoid (a = 6378137.0, f = 1/298.257223563).
/// </summary>
public sealed class LambertConformalConic
{
    private const double A = 6378137.0; // WGS84 semi-major axis (meters)
    private const double F = 1.0 / 298.257223563; // WGS84 flattening
    private static readonly double E = Math.Sqrt(2 * F - F * F); // eccentricity
    private static readonly double E2 = E * E;

    private readonly double _lonOriginRad;
    private readonly double _n;
    private readonly double _bigF;
    private readonly double _rho0;

    /// <summary>
    /// Creates a Lambert Conformal Conic projection centered on the given airport coordinates.
    /// Matches the AEDT Python script's createINMSpatialRef(lat, lon).
    /// </summary>
    /// <param name="latOriginDeg">Airport latitude in degrees (latitude of origin and both standard parallels).</param>
    /// <param name="lonOriginDeg">Airport longitude in degrees (central meridian).</param>
    public LambertConformalConic(double latOriginDeg, double lonOriginDeg)
    {
        _lonOriginRad = DegreesToRadians(lonOriginDeg);
        double lat0Rad = DegreesToRadians(latOriginDeg);

        // For tangential LCC (both standard parallels equal), n = sin(φ₀)
        // But we use the full ellipsoidal formulas for accuracy.
        double m0 = ComputeM(lat0Rad);
        double t0 = ComputeT(lat0Rad);

        _n = Math.Sin(lat0Rad);
        _bigF = m0 / (_n * Math.Pow(t0, _n));
        _rho0 = A * _bigF * Math.Pow(t0, _n);
    }

    /// <summary>
    /// Projects a WGS84 (longitude, latitude) coordinate to (easting, northing) in meters.
    /// </summary>
    public (double Easting, double Northing) Forward(double lonDeg, double latDeg)
    {
        double latRad = DegreesToRadians(latDeg);
        double lonRad = DegreesToRadians(lonDeg);

        double t = ComputeT(latRad);
        double rho = A * _bigF * Math.Pow(t, _n);

        // Normalize longitude difference to [-π, π] to match Esri's projection engine.
        // Without this, points more than 180° from the central meridian project
        // "the long way around" the globe, producing mirrored coordinates.
        double deltaLon = lonRad - _lonOriginRad;
        deltaLon = Math.Atan2(Math.Sin(deltaLon), Math.Cos(deltaLon));
        double theta = _n * deltaLon;

        double easting = rho * Math.Sin(theta);
        double northing = _rho0 - rho * Math.Cos(theta);

        return (easting, northing);
    }

    /// <summary>
    /// Inverse projects (easting, northing) in meters back to WGS84 (longitude, latitude) in degrees.
    /// </summary>
    public (double Longitude, double Latitude) Inverse(double easting, double northing)
    {
        double rhoPrime = Math.Sign(_n) * Math.Sqrt(easting * easting + (_rho0 - northing) * (_rho0 - northing));
        double thetaPrime = Math.Atan2(easting, _rho0 - northing);

        double t = Math.Pow(rhoPrime / (A * _bigF), 1.0 / _n);
        double lonRad = thetaPrime / _n + _lonOriginRad;
        double latRad = InverseT(t);

        // Normalize longitude to [-180, 180]
        double lonDeg = RadiansToDegrees(lonRad);
        lonDeg = ((lonDeg + 180.0) % 360.0) - 180.0;
        if (lonDeg < -180.0) lonDeg += 360.0;

        return (lonDeg, RadiansToDegrees(latRad));
    }

    /// <summary>
    /// Computes m(φ) = cos(φ) / sqrt(1 - e² sin²(φ))
    /// </summary>
    private static double ComputeM(double latRad)
    {
        double sinLat = Math.Sin(latRad);
        return Math.Cos(latRad) / Math.Sqrt(1.0 - E2 * sinLat * sinLat);
    }

    /// <summary>
    /// Computes t(φ) = tan(π/4 - φ/2) / ((1 - e·sin(φ)) / (1 + e·sin(φ)))^(e/2)
    /// </summary>
    private static double ComputeT(double latRad)
    {
        double sinLat = Math.Sin(latRad);
        double eSinLat = E * sinLat;
        return Math.Tan(Math.PI / 4.0 - latRad / 2.0)
               / Math.Pow((1.0 - eSinLat) / (1.0 + eSinLat), E / 2.0);
    }

    /// <summary>
    /// Iteratively inverts t to recover latitude (φ).
    /// Uses the standard iterative formula for ellipsoidal inverse.
    /// </summary>
    private static double InverseT(double t)
    {
        double lat = Math.PI / 2.0 - 2.0 * Math.Atan(t);

        for (int i = 0; i < 20; i++)
        {
            double eSinLat = E * Math.Sin(lat);
            double latNew = Math.PI / 2.0 - 2.0 * Math.Atan(t * Math.Pow((1.0 - eSinLat) / (1.0 + eSinLat), E / 2.0));

            if (Math.Abs(latNew - lat) < 1e-14)
                return latNew;

            lat = latNew;
        }

        return lat;
    }

    private static double DegreesToRadians(double deg) => deg * Math.PI / 180.0;
    private static double RadiansToDegrees(double rad) => rad * 180.0 / Math.PI;
}
