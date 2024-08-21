// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


document.addEventListener('DOMContentLoaded',
    () => {

        /*
         * Handle marking the current page
         * Note that this by itself does not work as we have altered going to the
         * About page with JavaScript below which means the href returns # so
         * additional JavaScript code is required in the About page
         */
        document.querySelectorAll('.nav-link').forEach(link => {
            
            link.classList.remove('border-bottom');
            link.classList.remove('border-top');

            if (link.getAttribute('href').toLowerCase() === location.pathname.toLowerCase()) {
                link.classList.add('border-dark');
                link.classList.add('border-bottom');
                link.classList.add('border-top');
            } else {
                link.classList.add('text-dark');
            }

        });
    });


/*
 *
 * Normally a web developer may have a link in the navigation and footer, duplicating the target location,
 * for web standards it's better to setup event handlers as shown below, in this case for navigation and footer
 * for the About page.
 *
 */
document.querySelectorAll('a#aboutFooter').forEach(link => {
    link.addEventListener('click', (e) => {
        window.location = 'About';
    });
});

document.querySelectorAll('a#aboutNav').forEach(link => {
    link.addEventListener('click', (e) => {
        window.location = 'About';
    });
});
