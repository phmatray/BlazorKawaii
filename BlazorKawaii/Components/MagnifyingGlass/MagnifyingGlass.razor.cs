using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a MagnifyingGlass character component with customizable mood and appearance.
/// </summary>
public partial class MagnifyingGlass : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 54 / 66.0;  // 54 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (79, 92.09);  // Fixed position in 240x240 viewBox
    }
}
