$(document).ready(function () {
    // prevent double click
    $("#demoForm").submit(function () {
        $(".submitBtn").attr("disabled", true);
        return true;
    });
});
