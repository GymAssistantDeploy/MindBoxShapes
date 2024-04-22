namespace MindBox.ShapesLibrary.Guards;

/// <summary>
/// Circle guard.
/// </summary>
internal static class CircleGuard
{
    /// <summary>
    /// Check the radius of the circle for correctness.
    /// </summary>
    /// <param name="radius">Radius.</param>
    /// <exception cref="ArgumentException">When radius isn't correct.</exception>
    public static void AgainstInvalidRadius(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Radius must be positive.");
        }
    }
}
