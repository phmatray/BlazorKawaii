using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents an astronaut character component with customizable mood and appearance.
/// </summary>
public partial class Astronaut : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(40.5)
        return 40.5 / 66.0;  // 40.5 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '99.82 67.77'
        return (99.82, 67.77);
    }
}
