using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Cat character component with customizable mood and appearance.
/// </summary>
public partial class Cat : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(51.67)
        return 51.67 / 66.0;  // 51.67 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.83 86.36'
        return (93.83, 86.36);  // Fixed position in 240x240 viewBox
    }
}
