// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
tinymce.init({
    selector: '#text-editor',
    resize: false,
    plugins: 'autoresize',
    max_height: 1000,
});