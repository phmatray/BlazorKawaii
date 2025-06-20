using BlazorKawaii.Common;
using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Components;

public partial class CreditCard
{
    [Parameter]
    public int Size { get; set; } = 200;

    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    [Parameter]
    public string Color { get; set; } = "#83D1FB";
  
    [Parameter]
    public string? ClassName { get; set; }

    protected override void OnInitialized()
    {
        
    }
}