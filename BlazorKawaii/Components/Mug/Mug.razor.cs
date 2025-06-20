using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class Mug
{
    [Parameter]
    public int Size { get; set; } = 200;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#A6E191";
  
    [Parameter]
    public string? ClassName { get; set; }
}