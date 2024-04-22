using MindBox.ShapesLibrary.Guards;
using MindBox.ShapesLibrary.Interfaces;

namespace MindBox.ShapesLibrary.Shapes;

/// <summary>
/// Circle.
/// </summary>
public class Circle : IHaveArea
{
    private readonly double radius;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="radius">Radius.</param>
    public Circle(double radius)
    {
        CircleGuard.AgainstInvalidRadius(radius);
        this.radius = radius;
    }

    /// <inheritdoc/>.
    public double CalculateArea()
    {
        return Math.PI * Math.Pow(this.radius, 2);
    }
}
