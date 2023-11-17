// An enhanced load allows users to navigate between different pages
window.Blazor.addEventListener("enhancedload", function () {
    // HTMX need to reprocess any htmx tags because of enhanced loading
    window.htmx.process(document.body);
});