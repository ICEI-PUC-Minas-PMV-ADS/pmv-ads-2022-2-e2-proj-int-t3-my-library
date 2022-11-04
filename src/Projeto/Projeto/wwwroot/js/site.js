// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function() {
    let navs = document.querySelectorAll(".nav li")
    navs = [...navs]
    for (nav of navs) {
        let link = nav.querySelectorAll("a")[0]
        if (link.href.includes(location.pathname)) {
            nav.classList.toggle("nav-item")
        }
    }
})()

//tggNav()

