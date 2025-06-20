using BlazorKawaii.Common;

namespace Demo.Pages.Index;

public class IndexFormModel
{
    public Mood Mood { get; set; } = Mood.Blissful;
    public int Size { get; set; } = 200;
    public string Color { get; set; } = "#FFD882";
}