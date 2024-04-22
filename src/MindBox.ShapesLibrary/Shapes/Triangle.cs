using System.Runtime.CompilerServices;
using MindBox.ShapesLibrary.Guards;
using MindBox.ShapesLibrary.Interfaces;

[assembly: InternalsVisibleTo("Mindbox.ShapesLibrary.Tests")]

namespace MindBox.ShapesLibrary.Shapes;

/// <summary>
/// Triangle.
/// </summary>
public class Triangle : IHaveArea
{
    private readonly double sideA;
    private readonly double sideB;
    private readonly double sideC;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="sideA">Side A.</param>
    /// <param name="sideB">Side B.</param>
    /// <param name="sideC">Side C.</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        TriangleGuard.AgainstInvalidSides(sideA, sideB, sideC);
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    /// <inheritdoc/>.
    public double CalculateArea()
    {
        var semiPerimeter = (this.sideA + this.sideB + this.sideC) / 2;
        var area = Math.Sqrt(semiPerimeter * (semiPerimeter - this.sideA) * (semiPerimeter - this.sideB) * (semiPerimeter - this.sideC));

        return area;
    }

    internal bool IsRightAngledTriangle()
    {
        const double tolerance = 0.0001;

        double[] sides =[this.sideA, this.sideB, this.sideC];
        Array.Sort(sides);

        var cSquare = Math.Pow(sides[2], 2);
        var abSquare = Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2);

        return Math.Abs(abSquare - cSquare) < tolerance;
    }
}
