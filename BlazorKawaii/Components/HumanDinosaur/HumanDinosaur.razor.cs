using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class HumanDinosaur : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(46.89)
        return 46.89 / 66.0;  // 46.89 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '97.66 123.76'
        return (97.66, 123.76);
    }
}
