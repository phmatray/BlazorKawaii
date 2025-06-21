using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Cat : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(51.67)
        return 51.67 / 66.0;  // 51.67 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '93.83 86.36'
        return (93.83, 86.36);  // Fixed position in 240x240 viewBox
    }
}
