using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Ghost : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(62.06)
        return 62.06 / 66.0;  // 62.06 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '89.09 99.3'
        return (89.09, 99.3);  // Fixed position in 240x240 viewBox
    }
}
