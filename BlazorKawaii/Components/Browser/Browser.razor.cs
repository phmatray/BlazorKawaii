using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Browser : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 52.78 / 66.0;  // 52.78 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (93.58, 115.38);  // Fixed position in 240x240 viewBox
    }
}