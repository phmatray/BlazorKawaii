using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Mug : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 53.95 / 66.0;  // 53.95 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (93.03, 107.33);  // Fixed position in 240x240 viewBox
    }
}