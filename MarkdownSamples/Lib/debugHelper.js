var $debugHelper = $debugHelper || {};
$debugHelper = function () {

    /*
     * Location for styles to outline all elements on the page
     */
    var href = "lib/debugger.css";

    /*
     * Added the debugger.css to the current page
     */
    var addCss = function () {

        if (styleStyleIsLoaded(href) === true) {
            return;
        }
        const head = document.head;
        const link = document.createElement("link");
        link.type = "text/css";
        link.rel = "stylesheet";
        link.href = href;
        head.appendChild(link);
    };

    /*
    * Removes debugger.css to the current page
    */
    var removeCss = function () {
        if (styleStyleIsLoaded('debugger.css')) {
            document.querySelector(`link[href$="${href}"]`).remove();
        }
    };

    /*
     * If development environment is true, then determine if debugger.css should be added or removed
     * for the current page.
     */
    var toggle = function (isDevelopmentEnvironment) {

        if (Boolean(isDevelopmentEnvironment)) {
            if (styleStyleIsLoaded(href) === true) {
                removeCss();
            } else {
                addCss();
            }
        }
    }

    /*
     * Determines if debugger.css is loaded on the current page.
     */
    var styleStyleIsLoaded = function () {
        for (var index = 0, count = document.styleSheets.length; index < count; index++) {
            const sheet = document.styleSheets[index];
            if (!sheet.href) {
                continue;
            }
            if (sheet.href.includes(href)) {
                return true;
            }
        }

        return false;
    }

    /*
     * Exposed functions
     */
    return {
        addCss: addCss,
        removeCss: removeCss,
        isCSSLinkLoaded: styleStyleIsLoaded,
        toggle: toggle
    };
}();