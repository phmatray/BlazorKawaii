using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class SpeechBubble
{
    [Parameter]
    public int Size { get; set; } = 170;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#83D1FB";
  
    [Parameter]
    public string? ClassName { get; set; }
}