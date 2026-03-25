using NetTopologySuite.Geometries;

namespace Contour.Core.Tests;

public static class ExampleSets
{
    /// <summary>
    /// Returns a set of coordinates that can be used for testing.
    /// This particular set is a 6x6 grid of coordinates.
    /// represents a contour line on the 40db interval, which has some intersections and mostly follows the border of the grid.
    /// </summary>
    public static List<CoordinateM> ExampleSet1()
    {
        // static Example set of coordinates
        return
        [
            new CoordinateM(0, 0, 39.96275),
            new CoordinateM(1, 0, 39.97202),
            new CoordinateM(2, 0, 39.98315),
            new CoordinateM(3, 0, 40.00205),
            new CoordinateM(4, 0, 40.01339),
            new CoordinateM(5, 0, 40.02472),

            new CoordinateM(0, 1, 40.00404),
            new CoordinateM(1, 1, 40.01235),
            new CoordinateM(2, 1, 40.0221),
            new CoordinateM(3, 1, 40.04178),
            new CoordinateM(4, 1, 40.05506),
            new CoordinateM(5, 1, 40.06582),

            new CoordinateM(0, 2, 40.04009),
            new CoordinateM(1, 2, 40.05103),
            new CoordinateM(2, 2, 40.061),
            new CoordinateM(3, 2, 40.0822),
            new CoordinateM(4, 2, 40.0957),
            new CoordinateM(5, 2, 40.10842),

            new CoordinateM(0, 3, 40.07994),
            new CoordinateM(1, 3, 40.09075),
            new CoordinateM(2, 3, 40.10183),
            new CoordinateM(3, 3, 40.12384),
            new CoordinateM(4, 3, 40.13641),
            new CoordinateM(5, 3, 40.14938),

            new CoordinateM(0, 4, 40.12228),
            new CoordinateM(1, 4, 40.13332),
            new CoordinateM(2, 4, 40.14446),
            new CoordinateM(3, 4, 40.16607),
            new CoordinateM(4, 4, 40.17762),
            new CoordinateM(5, 4, 40.18114),

            new CoordinateM(0, 5, 40.2101),
            new CoordinateM(1, 5, 40.22001),
            new CoordinateM(2, 5, 40.229),
            new CoordinateM(3, 5, 40.25246),
            new CoordinateM(4, 5, 40.26416),
            new CoordinateM(5, 5, 40.26603)
        ];
    }
}