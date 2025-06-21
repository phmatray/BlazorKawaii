using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Represents a HumanCat character component with customizable mood and appearance.
/// </summary>
public partial class HumanCat : KawaiiComponentBase
{
    /// <inheritdoc />
    protected override string DefaultColor => "#A6E191";

    /// <inheritdoc />
    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(46.29)
        return 46.29 / 66.0;  // 46.29 is the face width in Figma, 66 is the original face width
    }

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.2 77.66'
        return (93.2, 77.66);
    }
}
