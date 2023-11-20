// An enhanced load allows users to navigate between different pages
Blazor.addEventListener("enhancedload", function () {
    // HTMX need to reprocess any htmx tags because of enhanced loading
    htmx.process(document.body);
});