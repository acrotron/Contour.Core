using AwesomeAssertions;
using NetTopologySuite.Geometries;

namespace Contour.Core.Tests;

[TestClass]
public class UtilitiesTests
{
    [TestMethod]
    public void Interpolate_diagonal()
    {
        CoordinateM interpolate = Utilities.Interpolate(new CoordinateM(10, 10, 10), new CoordinateM(20, 20, 20), 15);
        interpolate.X.Should().Be(15);
        interpolate.Y.Should().Be(15);
        interpolate.M.Should().Be(15);
    }

    [TestMethod]
    public void Interpolate_linear()
    {
        CoordinateM interpolate = Utilities.Interpolate(new CoordinateM(10, 10, 10), new CoordinateM(10, 20, 20), 15);
        interpolate.X.Should().Be(10);
        interpolate.Y.Should().Be(15);
        interpolate.M.Should().Be(15);
    }

    [TestMethod]
    public void Interpolate_beyond_original_points()
    {
        CoordinateM interpolate = Utilities.Interpolate(new CoordinateM(10, 10, 10), new CoordinateM(10, 20, 20), 5);
        interpolate.X.Should().Be(10);
        interpolate.Y.Should().Be(5);
        interpolate.M.Should().Be(5);
    }

    [TestMethod]
    public void Interpolate_EqualMValues_ReturnsMidpoint()
    {
        CoordinateM interpolate = Utilities.Interpolate(new CoordinateM(10, 10, 10), new CoordinateM(10, 20, 10), 5);
        interpolate.X.Should().Be(10);
        interpolate.Y.Should().Be(15);
        interpolate.M.Should().Be(5);
    }

    [TestMethod]
    public void ContourPassesThroughEdge_regular_values()
    {
        Utilities.ContourPassesThroughEdge(10, 20, 15).Should().BeTrue();
        Utilities.ContourPassesThroughEdge(20, 10, 15).Should().BeTrue();
    }

    [TestMethod]
    public void ContourPassesThroughEdge_outside_values()
    {
        Utilities.ContourPassesThroughEdge(10, 20, 25).Should().BeFalse();
        Utilities.ContourPassesThroughEdge(20, 10, 25).Should().BeFalse();
    }

    [TestMethod]
    public void ContourPassesThroughEdge_identical_values()
    {
        Utilities.ContourPassesThroughEdge(10, 20, 10).Should().BeTrue();
        Utilities.ContourPassesThroughEdge(20, 10, 10).Should().BeTrue();
    }
}