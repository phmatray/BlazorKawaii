using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Gamepad character component with customizable mood and appearance.
/// </summary>
public partial class Gamepad : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#C9B6F2";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 58 / 66.0;  // 58 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (91, 122);  // Fixed position in 240x240 viewBox
    }
}
