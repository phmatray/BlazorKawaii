using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Airplane character component with customizable mood and appearance.
/// </summary>
public partial class Airplane : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 56 / 66.0;  // 56 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (92, 125.58);  // Fixed position in 240x240 viewBox
    }
}
