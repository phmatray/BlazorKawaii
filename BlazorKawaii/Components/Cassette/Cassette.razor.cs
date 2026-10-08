using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a Cassette character component with customizable mood and appearance.
/// </summary>
public partial class Cassette : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#FFB37A";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        return 52 / 66.0;  // 52 is the face width, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        return (88, 78);  // Fixed position in 240x240 viewBox
    }
}
