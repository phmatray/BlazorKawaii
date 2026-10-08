using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace BlazorKawaii.Common;

/// <summary>
/// Represents the face component that renders different expressions for Kawaii characters.
/// </summary>
public partial class Face : ComponentBase
{
    private readonly string _uniqueId = SvgMaskHelper.GetUniqueId();
    
    /// <summary>
    /// Gets or sets the mood expression to display.
    /// </summary>
    /// <value>The mood expression. Default is <see cref="Mood.Blissful"/>.</value>
    [Parameter]
    public Mood Mood { get; set; } = Mood.Blissful;
    
    /// <summary>
    /// Gets or sets a custom SVG transform attribute.
    /// </summary>
    /// <value>A custom transform string. If not provided, a transform is calculated from X, Y, and Scale.</value>
    [Parameter]
    public string? Transform { get; set; }
    
    /// <summary>
    /// Gets or sets the scale factor for the face.
    /// </summary>
    /// <value>The scale factor. Default is 1.0.</value>
    [Parameter]
    public double Scale { get; set; } = 1.0;
    
    /// <summary>
    /// Gets or sets the X position for the face.
    /// </summary>
    /// <value>The X coordinate in SVG units.</value>
    [Parameter]
    public double X { get; set; }
    
    /// <summary>
    /// Gets or sets the Y position for the face.
    /// </summary>
    /// <value>The Y coordinate in SVG units.</value>
    [Parameter]
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the fill color of the mouth.
    /// </summary>
    /// <value>Any SVG color. Default is black; a mascot can use it to turn the mouth into a beak.</value>
    [Parameter]
    public string MouthColor { get; set; } = "#000000";

    /// <summary>
    /// Gets or sets the fill color of the eyes.
    /// </summary>
    /// <value>Any SVG color. Default is black. The cheeks keep their translucent blush.</value>
    [Parameter]
    public string EyeColor { get; set; } = "#000000";

    /// <summary>
    /// Gets or sets the fill color of the cheeks.
    /// </summary>
    /// <value>Any SVG color. Default is black, drawn translucent; a custom color is drawn more opaque so it stays visible on dark art.</value>
    [Parameter]
    public string BlushColor { get; set; } = "#000000";

    /// <summary>
    /// Gets the unique identifier for this face instance.
    /// </summary>
    private string UniqueId => _uniqueId;
    
    /// <summary>
    /// Generates the SVG transform attribute for positioning and scaling the face.
    /// </summary>
    /// <returns>A formatted SVG transform string.</returns>
    private string GetTransform()
    {
        if (!string.IsNullOrEmpty(Transform))
            return Transform;
        
        var xStr = X.ToString(CultureInfo.InvariantCulture);
        var yStr = Y.ToString(CultureInfo.InvariantCulture);
        var scaleStr = Scale.ToString(CultureInfo.InvariantCulture);
        
        return $"translate({xStr} {yStr}) scale({scaleStr})";
    }

    private string RootClass => $"kawaii-face kawaii-face--{Mood.ToString().ToLowerInvariant()}";
}