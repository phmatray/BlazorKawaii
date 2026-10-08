namespace BlazorKawaii.Common;

/// <summary>
/// The stylesheet an animated <see cref="Face"/> renders inside its own root group, so the animation
/// works without any stylesheet reference on the consumer's side.
/// </summary>
/// <remarks>
/// Every rule is scoped under <c>.kawaii-face--animated</c> and a mood modifier, so the text is identical
/// for every instance. It contains no <c>&lt;</c>, <c>&gt;</c>, quote or ampersand, so HTML-encoding the
/// text of the <c>&lt;style&gt;</c> element never alters it.
/// </remarks>
internal static class FaceAnimations
{
    // Dizzy spirals turn around their outer arc's centre, which sits 10 units right of and below the
    // top-left corner of each spiral's fill box, not at the box's centre: the spiral is lopsided.
    // The cheeks glow multiplies the opacity the cheeks group carries (--kawaii-cheeks-opacity).
    internal const string Css = """
        .kawaii-face--animated .kawaii-face__eyes, .kawaii-face--animated .kawaii-face__eyes path, .kawaii-face--animated .kawaii-face__mouth { transform-box: fill-box; transform-origin: center; }
        .kawaii-face--animated.kawaii-face--happy .kawaii-face__eyes, .kawaii-face--animated.kawaii-face--sad .kawaii-face__eyes, .kawaii-face--animated.kawaii-face--shocked .kawaii-face__eyes, .kawaii-face--animated.kawaii-face--excited .kawaii-face__eyes { animation: kawaii-blink 4s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--excited .kawaii-face__mouth { animation: kawaii-bounce .6s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--sad .kawaii-face__mouth { animation: kawaii-droop 3s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--blissful .kawaii-face__cheeks g { animation: kawaii-glow 3s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--lovestruck .kawaii-face__eyes path { animation: kawaii-heartbeat 1.2s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--ko .kawaii-face__eyes path { animation: kawaii-wobble 1.5s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--sleepy .kawaii-face__mouth { animation: kawaii-snore 3s ease-in-out infinite; }
        .kawaii-face--animated.kawaii-face--dizzy .kawaii-face__eyes path { transform-origin: 10px 10px; animation: kawaii-spin 2s linear infinite; }
        .kawaii-face--animated.kawaii-face--dizzy .kawaii-face__eyes path:last-child { animation-direction: reverse; }
        @keyframes kawaii-blink { 0%, 94%, 100% { transform: scaleY(1); } 97% { transform: scaleY(.1); } }
        @keyframes kawaii-bounce { 0%, 100% { transform: translateY(0); } 50% { transform: translateY(-2px); } }
        @keyframes kawaii-droop { 0%, 100% { transform: translateY(0); } 50% { transform: translateY(1.5px); } }
        @keyframes kawaii-glow { 50% { opacity: calc(var(--kawaii-cheeks-opacity) * 1.6); } }
        @keyframes kawaii-heartbeat { 0%, 28%, 70%, 100% { transform: scale(1); } 14% { transform: scale(1.15); } 42% { transform: scale(1.1); } }
        @keyframes kawaii-wobble { 0%, 100% { transform: rotate(0); } 25% { transform: rotate(-8deg); } 75% { transform: rotate(8deg); } }
        @keyframes kawaii-snore { 0%, 100% { transform: scale(1); } 50% { transform: scale(1.25); } }
        @keyframes kawaii-spin { to { transform: rotate(360deg); } }
        @media (prefers-reduced-motion: reduce) { .kawaii-face--animated * { animation: none !important; } }
        """;
}
