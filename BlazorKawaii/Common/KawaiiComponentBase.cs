using Microsoft.AspNetCore.Components;

namespace BlazorKawaii.Common;

/// <summary>
/// Base class for all Kawaii components providing common functionality and properties.
/// </summary>
public abstract class KawaiiComponentBase : ComponentBase
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();

    /// <summary>
    /// Gets or sets the size of the component in pixels.
    /// </summary>
    /// <value>The size in pixels. Default is 240.</value>
    [Parameter]
    public int Size { get; set; } = 240;

    /// <summary>
    /// Gets or sets the mood expression of the component.
    /// </summary>
    /// <value>The mood expression. Default is <see cref="Mood.Blissful"/>.</value>
    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;

    /// <summary>
    /// Gets or sets the primary color of the component in hexadecimal format.
    /// </summary>
    /// <value>The color in hex format (e.g., "#A6E191"). If null, uses the component's default color.</value>
    [Parameter]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the CSS class to apply to the component wrapper.
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <summary>
    /// Gets or sets the inline CSS style to apply to the component wrapper.
    /// </summary>
    [Parameter]
    public string? Style { get; set; }
    
    /// <summary>
    /// Gets or sets the CSS class to apply to the SVG element.
    /// </summary>
    [Parameter]
    public string? SvgClass { get; set; }
    
    /// <summary>
    /// Gets or sets the inline CSS style to apply to the SVG element.
    /// </summary>
    [Parameter]
    public string? SvgStyle { get; set; }

    /// <summary>
    /// Gets the default color for the component.
    /// </summary>
    protected abstract string DefaultColor { get; }

    /// <summary>
    /// Gets the effective color for the component, using the specified color or falling back to the default.
    /// </summary>
    /// <returns>The color to use for rendering.</returns>
    protected string GetColor() => Color ?? DefaultColor;

    /// <summary>
    /// Gets the unique identifier for this component instance, used for SVG mask IDs.
    /// </summary>
    /// <returns>A unique string identifier.</returns>
    protected string GetUniqueId() => _uniqueId;

    /// <summary>
    /// Gets the scale factor for the face element.
    /// </summary>
    /// <returns>The face scale factor.</returns>
    protected abstract double GetFaceScale();

    /// <summary>
    /// Gets the position coordinates for the face element.
    /// </summary>
    /// <returns>A tuple containing the x and y coordinates.</returns>
    protected abstract (double x, double y) GetFacePosition();
}
