using MindBox.ShapesLibrary.Shapes;

namespace Mindbox.ShapesLibrary.Tests;

/// <summary>
/// Tests for <see cref="Circle"/>.
/// </summary>
public class CircleTest
{
    private const int ToleranceForTriangleArea = 6;

    [Theory]
    [MemberData(nameof(InvalidRadiusData))]
    public void CircleConstructor_InvalidCircle_ThrowsArgumentException(double radius)
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentException>(() => new Circle(radius));
    }

    public static TheoryData<double> InvalidRadiusData =>
        new()
        {
            -1,
            0,
        };

    [Theory]
    [MemberData(nameof(ValidCircleWithAreaData))]
    public void CalculateArea_ValidCircle_ReturnsExpectedArea(double radius, double expectedArea)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        var actualArea = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, actualArea, ToleranceForTriangleArea);
    }

    public static TheoryData<double, double> ValidCircleWithAreaData =>
        new()
        {
            { 1, Math.PI },
            { 2, Math.PI * 4 },
            { 3.5, Math.PI * 12.25 },
            { 10, Math.PI * 100 },
        };
}
