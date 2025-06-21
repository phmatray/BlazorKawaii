using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a browser window character component with customizable mood and appearance.
/// </summary>
public partial class Browser : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(52.78)
        return 52.78 / 66.0;  // 52.78 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.58 115.38'
        return (93.58, 115.38);  // Fixed position in 240x240 viewBox
    }
}