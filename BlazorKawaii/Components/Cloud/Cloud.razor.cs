using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Cloud character component with customizable mood and appearance.
/// </summary>
public partial class Cloud : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 60 / 66.0;  // 60 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (94, 122.55);  // Fixed position in 240x240 viewBox
    }
}
