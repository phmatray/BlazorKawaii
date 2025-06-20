using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class Browser
{
    [Parameter]
    public int Size { get; set; } = 180;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Ko;

    [Parameter]
    public string Color { get; set; } = "#FDA7DC";
  
    [Parameter]
    public string? ClassName { get; set; }
}