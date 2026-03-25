using AwesomeAssertions;
using NetTopologySuite.Geometries;

namespace Contour.Core.Tests;

[TestClass]
public class TriExtTests
{
    [TestMethod]
    public void GetEdgeWithIncorrectIndexWillThrowException()
    {
        TriExt triExt = new TriExt(1, new CoordinateM(0, 0, 0), new CoordinateM(10, 0, 0), new CoordinateM(10, 10, 0));
        Action action = () => triExt.GetEdge(4);
        action.Should().Throw<ArgumentOutOfRangeException>();
    }
}