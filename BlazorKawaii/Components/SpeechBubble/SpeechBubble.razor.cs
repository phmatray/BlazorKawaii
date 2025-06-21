using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a SpeechBubble character component with customizable mood and appearance.
/// </summary>
public partial class SpeechBubble : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 56.77 / 66.0;  // 56.77 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (91.61, 108.57);  // Fixed position in 240x240 viewBox
    }
}