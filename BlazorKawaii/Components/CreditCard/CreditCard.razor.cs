using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

public partial class CreditCard : KawaiiComponentBase
{
    protected override string DefaultColor => "#A6E191";

    protected override double GetFaceScale()
    {
        return 54.33 / 66.0;  // 54.33 is the face width in Figma, 66 is the original face width
    }

    protected override (double x, double y) GetFacePosition()
    {
        return (93.33, 121.1);  // Fixed position in 240x240 viewBox
    }
}