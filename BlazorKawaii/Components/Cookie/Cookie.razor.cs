using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Cookie character component with customizable mood and appearance.
/// </summary>
public partial class Cookie : KawaiiComponentBase
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
        return (90, 112.55);  // Fixed position in 240x240 viewBox
    }
}
