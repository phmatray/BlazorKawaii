using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Cyborg : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        // From React: figmaFaceScale = getFaceScale(50.24)
        return 50.24 / 66.0;  // 50.24 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        // From React: figmaFaceXYPosition = '94.66 77.2'
        return (94.66, 77.2);
    }
}
