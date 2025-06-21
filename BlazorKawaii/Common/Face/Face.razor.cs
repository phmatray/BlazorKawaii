using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazorKawaii.Common;

public partial class Face : ComponentBase
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();
    
    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;
    
    [Parameter]
    public string? Transform { get; set; }
    
    [Parameter]
    public double Scale { get; set; } = 1.0;
    
    [Parameter]
    public double X { get; set; }
    
    [Parameter]
    public double Y { get; set; }
    
    private string UniqueId => _uniqueId;
    
    private string GetTransform()
    {
        if (!string.IsNullOrEmpty(Transform))
            return Transform;
        
        var xStr = X.ToString(CultureInfo.InvariantCulture);
        var yStr = Y.ToString(CultureInfo.InvariantCulture);
        var scaleStr = Scale.ToString(CultureInfo.InvariantCulture);
        
        return $"translate({xStr} {yStr}) scale({scaleStr})";
    }
}