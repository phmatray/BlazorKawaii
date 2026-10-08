using BlazorKawaii.Common;

namespace BlazorKawaii.Components;

/// <summary>
/// Renders only the kawaii face (eyes, blush and mouth) in a tight, transparent SVG,
/// so it can be laid over your own artwork. <see cref="KawaiiComponentBase.Size"/> is the width in pixels;
/// <see cref="KawaiiComponentBase.Color"/> colors the eyes and the mouth (black by default).
/// </summary>
public partial class KawaiiFace : KawaiiComponentBase
{
    // Measured union of the face's bounding box over every Mood (the Dizzy spirals reach
    // x -4..71 and y -7.1 in face coordinates, the Shocked mouth y 40), plus 1 unit of padding,
    // rounded up. Re-measure when a mood is added.
    private const double ViewBoxWidth = 77;
    private const double ViewBoxHeight = 50;
    private const double OffsetX = 5;
    private const double OffsetY = 9;

    /// <inheritdoc />
    protected override string DefaultColor => "#000000";

    /// <inheritdoc />
    protected override double GetFaceScale() => 1.0;

    /// <inheritdoc />
    protected override (double x, double y) GetFacePosition() => (OffsetX, OffsetY);
}
