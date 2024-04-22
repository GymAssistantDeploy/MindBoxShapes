using MindBox.ShapesLibrary.Interfaces;
using MindBox.ShapesLibrary.Shapes;

namespace Mindbox.ShapesLibrary.Tests;

/// <summary>
/// Tests for shapes that implement the <see cref="IHaveArea"/> interface.
/// </summary>
public class TriangleTest
{
    private const int ToleranceForTriangleArea = 6;

    [Theory]
    [MemberData(nameof(TrianglesSidesWithCorrectAreaData))]
    public void ValidTriangle_CalculateArea_ShouldBeCorrect(double sideA, double sideB, double sideC, double expectedArea)
    {
        // Arrange
        var triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var actualArea = triangle.CalculateArea();

        // Assert
        Assert.Equal(actualArea, expectedArea, ToleranceForTriangleArea);
    }

    public static TheoryData<double, double, double, double> TrianglesSidesWithCorrectAreaData =>
        new()
        {
            { 3, 4, 5, 6 }, // Right-angled triangle with sides 3, 4, and 5.
            { 6, 8, 10, 24 }, // Right-angled triangle with sides 6, 8, and 10.
            { 5, 12, 13, 30 }, // Right-angled triangle with sides 5, 12, and 13.
            { 5, 5, 5, 10.825317547305485 } // Equilateral triangle with sides 5, 5, and 5.
        };

    [Theory]
    [MemberData(nameof(TrianglesSidesWithRightAngledAnswerData))]
    public void ValidTriangle_IsRightAngledTriangle_ReturnsExpectedResult(double sideA, double sideB, double sideC, bool expectedResult)
    {
        // Arrange
        Triangle triangle = new Triangle(sideA, sideB, sideC);

        // Act
        var actualResult = triangle.IsRightAngledTriangle();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<double, double, double, bool> TrianglesSidesWithRightAngledAnswerData =>
        new()
        {
            { 3, 4, 5, true },
            { 6, 8, 10, true },
            { 5, 12, 13, true },
            { 5, 5, 5, false },
        };

    [Theory]
    [MemberData(nameof(InvalidTriangleData))]
    public void InvalidTriangle_Constructor_ThrowArgumentException(double sideA, double sideB, double sideC)
    {
        // Arrange, Act, Assert
        Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
    }

    public static TheoryData<double, double, double> InvalidTriangleData =>
        new()
        {
            { 0, 1, 2 },
            { 1, 0, 2 },
            { 1, 2, 0 },
            { 1, 2, 3 },
            { 1, 3, 1 },
        };
}
