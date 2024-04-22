namespace MindBox.ShapesLibrary.Guards;

/// <summary>
/// Triangle guard.
/// </summary>
internal static class TriangleGuard
{
    /// <summary>
    /// Check the sides of the triangle for correctness.
    /// </summary>
    /// <param name="sideA">Side A.</param>
    /// <param name="sideB">Side B.</param>
    /// <param name="sideC">Side C.</param>
    /// <exception cref="ArgumentException">When sides aren't correct.</exception>
    public static void AgainstInvalidSides(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Sides must be positive.");
        }

        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException("The sum of the lengths of any two sides of a triangle must be greater than the length of the third side.");
        }
    }
}
