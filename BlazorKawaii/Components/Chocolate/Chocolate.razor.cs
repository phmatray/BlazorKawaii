using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class Chocolate : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 53.99 / 66.0;  // 53.99 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (93, 156.26);  // Fixed position in 240x240 viewBox
    }
}