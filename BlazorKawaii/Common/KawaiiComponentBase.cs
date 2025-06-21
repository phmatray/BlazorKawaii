using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Common;

public abstract class KawaiiComponentBase : ComponentBase
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();

    [Parameter]
    public int Size { get; set; } = 240;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string? Color { get; set; }

    [Parameter]
    public string? Class { get; set; }

    [Parameter]
    public string? Style { get; set; }
    
    [Parameter]
    public string? SvgClass { get; set; }
    
    [Parameter]
    public string? SvgStyle { get; set; }

    protected abstract string DefaultColor { get; }

    protected string GetColor() => Color ?? DefaultColor;

    protected string GetUniqueId() => _uniqueId;

    protected abstract double GetFaceScale();

    protected abstract (double x, double y) GetFacePosition();
}
