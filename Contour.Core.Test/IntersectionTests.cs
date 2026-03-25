using AwesomeAssertions;
using NetTopologySuite.Geometries;

namespace Contour.Core.Tests;

[TestClass]
public class IntersectionTests
{
    [TestMethod]
    public void GetIntersections()
    {
        TriExt triangle = new TriExt(1, 
            new CoordinateM(0, 0, 30), 
            new CoordinateM(10, 0, 35), 
            new CoordinateM(10, 10, 36));

        List<Intersection> intersections = Intersection.GetIntersections(30, triangle);

        intersections[0].InterpolatedValue.M.Should().Be(30);
        intersections[0].TriEdge.Start.M.Should().Be(30);
        intersections[0].TriEdge.End.M.Should().Be(35);

        intersections[1].InterpolatedValue.M.Should().Be(30);
        intersections[1].TriEdge.Start.M.Should().Be(36);
        intersections[1].TriEdge.End.M.Should().Be(30);

        intersections.Count.Should().Be(2);
    }
}