﻿namespace BlazorKawaii.Components;

/// <summary>
/// Provides SVG path data for the Ghost component.
/// </summary>
public static class GhostPaths
{
    /// <summary>
    /// Gets the SVG path data for the Ghost body.
    /// </summary>
    public const string Body = @"
        <path
            fill=""currentColor""
            fill-rule=""evenodd""
            d=""M118.241 41.032C84.925 42.164 59 74.852 59 112.904v71.716c0 7.632 5.484 13.84 12.224 13.84s12.223-6.208 12.223-13.839c0-2.544 1.828-4.613 4.075-4.613 2.246 0 4.074 2.069 4.074 4.613 0 7.631 5.483 13.839 12.224 13.839 3.265 0 6.334-1.44 8.643-4.053 2.309-2.614 3.58-6.09 3.58-9.786 0-2.55 1.822-4.613 4.075-4.613 2.246 0 4.074 2.069 4.074 4.613 0 7.631 5.484 13.839 12.224 13.839s12.223-6.208 12.223-13.839c0-2.544 1.828-4.613 4.075-4.613 2.246 0 4.074 2.069 4.074 4.613 0 7.631 5.484 13.839 12.224 13.839s12.223-6.208 12.223-13.839v-74.425c0-38.577-28.038-70.35-62.994-69.164Z""
            clip-rule=""evenodd""
        />
        <path
            fill=""#121212""
            fill-opacity=""0.1""
            fill-rule=""evenodd""
            d=""M163.84 197.16c4.163-2.21 7.052-7 7.052-12.539v-74.425c0-35.354-23.548-64.993-54.389-68.786a4.724 4.724 0 0 1 1.738-.378c34.956-1.186 62.994 30.587 62.994 69.164v74.425c0 7.631-5.483 13.839-12.223 13.839-1.848 0-3.6-.466-5.172-1.3Z""
            clip-rule=""evenodd""
        />";
}
