using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class Cat
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();
    
    [Parameter]
    public int Size { get; set; } = 320;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#596881";
  
    [Parameter]
    public string? ClassName { get; set; }
}