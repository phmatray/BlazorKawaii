using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class Backpack
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();
    
    [Parameter]
    public int Size { get; set; } = 240;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#FFD882";
  
    [Parameter]
    public string? ClassName { get; set; }
}