using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class HumanCat : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(46.29)
        return 46.29 / 66.0;  // 46.29 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.2 77.66'
        return (93.2, 77.66);
    }
}
