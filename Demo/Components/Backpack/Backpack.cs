using Demo.Common;
using Microsoft.AspNetCore.Components;

namespace Demo.Components.Backpack;

public partial class Backpack
{
    [Parameter]
    public int Size { get; set; } = 240;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#FFD882";
  
    [Parameter]
    public string? ClassName { get; set; }
}