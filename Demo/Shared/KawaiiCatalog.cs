using System.Diagnostics.CodeAnalysis;
using BlazorKawaii.Common;
using BlazorKawaii.Components;

namespace Demo.Shared;

/// <summary>
/// One mascot of the library, renderable through <c>DynamicComponent</c>.
/// </summary>
/// <param name="Type">The component type; annotated so trimming keeps its parameters.</param>
public sealed record KawaiiEntry(
    [property: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    [param: DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)]
    Type Type)
{
    /// <summary>Gets the component name, as typed in Razor.</summary>
    public string Name => Type.Name;

    /// <summary>Gets the resource key of the mascot's description.</summary>
    public string DescriptionKey => $"{Name}Desc";
}

/// <summary>
/// The single list of mascots shown by the demo (gallery, playground, documentation).
/// </summary>
public static class KawaiiCatalog
{
    /// <summary>Gets every mascot, in alphabetical order.</summary>
    public static IReadOnlyList<KawaiiEntry> All { get; } =
    [
        new(typeof(Airplane)),
        new(typeof(Astronaut)),
        new(typeof(Backpack)),
        new(typeof(Browser)),
        new(typeof(Cassette)),
        new(typeof(Cat)),
        new(typeof(Chocolate)),
        new(typeof(Cloud)),
        new(typeof(Cookie)),
        new(typeof(CreditCard)),
        new(typeof(Cyborg)),
        new(typeof(BlazorKawaii.Components.File)),
        new(typeof(Folder)),
        new(typeof(Ghost)),
        new(typeof(HumanCat)),
        new(typeof(HumanDinosaur)),
        new(typeof(IceCream)),
        new(typeof(MagnifyingGlass)),
        new(typeof(Mug)),
        new(typeof(Padlock)),
        new(typeof(Planet)),
        new(typeof(RubberDuck)),
        new(typeof(SpeechBubble))
    ];

    /// <summary>Gets the moods in display order.</summary>
    public static IReadOnlyList<Mood> Moods { get; } = Enum.GetValues<Mood>();

    /// <summary>Gets the demo's pastel palette, used to show mascots in varied colors.</summary>
    public static IReadOnlyList<string> Palette { get; } =
        ["#A6E191", "#FFD882", "#83D1FB", "#FF8EAD", "#C9B6F2", "#FFB37A"];

    /// <summary>Finds a mascot by name (case-insensitive).</summary>
    public static KawaiiEntry? Find(string? name) =>
        All.FirstOrDefault(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));

    /// <summary>Builds the parameters for <c>DynamicComponent</c>.</summary>
    public static Dictionary<string, object> Parameters(Mood mood, int size, string color) => new()
    {
        [nameof(KawaiiComponentBase.Mood)] = mood,
        [nameof(KawaiiComponentBase.Size)] = size,
        [nameof(KawaiiComponentBase.Color)] = color
    };
}
