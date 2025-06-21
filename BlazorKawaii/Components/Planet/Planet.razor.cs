using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Planet : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 66 / 66.0;  // 66 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (87, 110);  // Fixed position in 240x240 viewBox
    }
}