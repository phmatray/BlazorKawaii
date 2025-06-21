using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a CreditCard character component with customizable mood and appearance.
/// </summary>
public partial class CreditCard : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 54.33 / 66.0;  // 54.33 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (93.33, 121.1);  // Fixed position in 240x240 viewBox
    }
}