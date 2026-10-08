using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a RubberDuck character component with customizable mood and appearance.
/// </summary>
public partial class RubberDuck : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 58 / 66.0;  // 58 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (91, 91.06);  // Fixed position in 240x240 viewBox
    }
}
