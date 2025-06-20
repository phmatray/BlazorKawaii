using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class Ghost
{
    [Parameter]
    public int Size { get; set; } = 240;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#E0E4E8";
  
    [Parameter]
    public string? ClassName { get; set; }
}