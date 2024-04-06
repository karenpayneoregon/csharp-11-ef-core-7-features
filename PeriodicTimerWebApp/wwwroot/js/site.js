document.addEventListener('DOMContentLoaded', () => {

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