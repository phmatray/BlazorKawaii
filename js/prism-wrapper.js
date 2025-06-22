// Prism.js wrapper to prevent DOM manipulation conflicts with Blazor
window.PrismWrapper = {
    highlightCode: function() {
        if (typeof Prism === 'undefined') {
            return;
        }

        try {
            // Get all code blocks that need highlighting
            const codeBlocks = document.querySelectorAll('pre code:not(.prism-highlighted)');
            
            codeBlocks.forEach(block => {
                if (!block || block.classList.contains('prism-highlighted')) {
                    return;
                }

                // Clone the element to avoid direct DOM manipulation
                const clone = block.cloneNode(true);
                
                // Apply Prism highlighting to the clone
                Prism.highlightElement(clone, false);
                
                // Copy the highlighted content back
                block.innerHTML = clone.innerHTML;
                block.className = clone.className;
                
                // Mark as highlighted to prevent re-processing
                block.classList.add('prism-highlighted');
            });
        } catch (error) {
            console.warn('Prism highlighting error:', error);
        }
    },

    reset: function() {
        // Remove highlighting markers when needed
        const highlightedBlocks = document.querySelectorAll('.prism-highlighted');
        highlightedBlocks.forEach(block => {
            block.classList.remove('prism-highlighted');
        });
    }
};

// Replace the global highlightCode function
window.highlightCode = window.PrismWrapper.highlightCode;