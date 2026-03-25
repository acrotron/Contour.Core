using AwesomeAssertions;

namespace Contour.Core.Tests;

[TestClass]
public class Wgs84GeometryPrecisionTests
{
    [TestMethod]
    public void VerifyPrecision()
    {
        Wgs84GeometryPrecision geometryPrecision = new Wgs84GeometryPrecision();
        geometryPrecision.GeometryFactory.PrecisionModel.Scale.Should().Be(1000);
    }
}