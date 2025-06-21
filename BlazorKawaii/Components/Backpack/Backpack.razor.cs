using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a backpack character component with customizable mood and appearance.
/// </summary>
public partial class Backpack : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(50.73)
        return 50.73 / 66.0;  // 50.73 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '94.67 106.5'
        return (94.67, 106.5);  // Fixed position in 240x240 viewBox
    }
}
