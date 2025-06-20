using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Common.Face;

public partial class Face
{
    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string? Transform { get; set; }
  
    [Parameter]
    public string? UniqueId { get; set; }
}