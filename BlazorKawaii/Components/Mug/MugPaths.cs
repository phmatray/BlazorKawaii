﻿namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the Mug component.
/// </summary>
public static class MugPaths
{
    /// <summary>
    /// Gets the SVG path data for the Mug body.
    /// </summary>
    public const string Body = @"
        <path
            fill=""currentColor""
            fill-rule=""evenodd""
            d=""M66.953 91.194H49.379C41.45 91.194 35 97.314 35 104.839c0 17.795 14.127 32.491 32.29 34.588C69.498 154.968 83.53 167 100.503 167h41.538c18.501 0 33.55-14.283 33.55-31.839V77.548c0-2.512-2.146-4.548-4.793-4.548H71.746c-2.646 0-4.793 2.036-4.793 4.548v13.646Zm-.713 9.096v29.896c-12.694-2.157-22.367-12.689-22.367-25.347 0-2.508 2.15-4.549 4.793-4.549H66.24Z""
            clip-rule=""evenodd""
        />
        <path
            fill=""#000""
            fill-rule=""evenodd""
            d=""M121.643 73h-.086v94h.086V73Zm42.338 0c2.301 0 4.168 2.036 4.168 4.548v57.613c0 17.556-13.087 31.839-29.175 31.839h2.837c18.627 0 33.78-14.283 33.78-31.839V77.548c0-2.512-2.161-4.548-4.826-4.548h-6.784Z""
            clip-rule=""evenodd""
            opacity=""0.1""
        />";
}