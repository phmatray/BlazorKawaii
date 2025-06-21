using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a HumanDinosaur character component with customizable mood and appearance.
/// </summary>
public partial class HumanDinosaur : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(46.89)
        return 46.89 / 66.0;  // 46.89 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '97.66 123.76'
        return (97.66, 123.76);
    }
}
