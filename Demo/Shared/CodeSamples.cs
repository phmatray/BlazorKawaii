using BlazorKawaii.Common;

namespace Demo.Shared;

/// <summary>
/// Razor snippets shown in the demo. Kept in C# because "@*" inside a Razor @code block
/// would be parsed as a Razor comment.
/// </summary>
public static class CodeSamples
{
    /// <summary>Full usage example for one mascot, with localized comments.</summary>
    public static string ComponentExample(string name, Mood mood, string color,
        string basicComment, string propertiesComment, string allMoodsComment) => $$"""
        @using BlazorKawaii.Components
        @using BlazorKawaii.Common

        @* {{basicComment}} *@
        <{{name}} />

        @* {{propertiesComment}} *@
        <{{name}}
            Mood="Mood.{{mood}}"
            Size="240"
            Color="{{color}}" />

        @* {{allMoodsComment}} *@
        @foreach (Mood mood in Enum.GetValues<Mood>())
        {
            <{{name}} Mood="@mood" Size="100" />
        }
        """;
}
