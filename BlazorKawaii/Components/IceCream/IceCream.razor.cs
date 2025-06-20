using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class IceCream
{
    [Parameter]
    public int Size { get; set; } = 300;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#FCCB7E";
  
    [Parameter]
    public string? ClassName { get; set; }
}