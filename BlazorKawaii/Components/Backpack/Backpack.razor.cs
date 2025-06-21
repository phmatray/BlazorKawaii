using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Backpack : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 50.73 / 66.0;  // 50.73 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (94.67, 106.5);  // Fixed position in 240x240 viewBox
    }
}
