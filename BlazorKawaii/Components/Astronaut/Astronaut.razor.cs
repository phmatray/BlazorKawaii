using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Astronaut : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(40.5)
        return 40.5 / 66.0;  // 40.5 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '99.82 67.77'
        return (99.82, 67.77);
    }
}
