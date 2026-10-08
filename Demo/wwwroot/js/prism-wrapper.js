// Prism only returns highlighted HTML; Blazor renders it, so Prism never edits Blazor-owned DOM.
window.PrismWrapper = {
    highlight: function (code, language) {
        const grammar = window.Prism && Prism.languages[language];
        return grammar ? Prism.highlight(code, grammar, language) : null;
    }
};
