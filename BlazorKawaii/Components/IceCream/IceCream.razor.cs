using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class IceCream : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(53.99)
        return 53.99 / 66.0;  // 53.99 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.38 96.26'
        return (93.38, 96.26);  // Fixed position in 240x240 viewBox
    }
}
