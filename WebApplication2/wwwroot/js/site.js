// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Define global flag
// Write your JavaScript code.
function toogleSlidebar() {
    var sidebar = document.getElementById('custom-sidebar');
    var background = document.getElementById('custom-background');
    if (sidebar.classList.contains('collapsed')) {
        sidebar.classList.remove('collapsed');
        background.classList.add('bg-gray-500');
    } else {
        sidebar.classList.add('collapsed');
        background.classList.remove('bg-gray-500')
    }
}

document.getElementById('toggleButton').addEventListener('click', function (event) {
    console.log("toggleButton")
    event.stopPropagation();
    toogleSlidebar();
});

document.getElementById('inner-sidebar').addEventListener('click', function (event) {
    event.stopPropagation();
})

document.getElementById('click-background').addEventListener('click', function () {
    toogleSlidebar();
})
