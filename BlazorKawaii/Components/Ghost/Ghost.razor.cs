using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Ghost character component with customizable mood and appearance.
/// </summary>
public partial class Ghost : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(62.06)
        return 62.06 / 66.0;  // 62.06 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '89.09 99.3'
        return (89.09, 99.3);  // Fixed position in 240x240 viewBox
    }
}
