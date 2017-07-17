$(function () {

    validatedecimals();
    validinputs();
    var pathname = window.location.pathname;
    if (pathname.includes("/Admin/Groups"))
        $("#ligroups").addClass("active");
    else if (pathname.includes("/Admin/Users"))
        $("#liuser").addClass("active");
    else if (pathname.includes("/Admin/dashboard"))
        $("#lidashboard").addClass("active");
    else if (pathname.includes("/Admin/Charity" || "/Admin/Charity/Create"))
        $("#liCharity").addClass("active");
    else if (pathname.includes("/Admin/Cause" || "/Admin/Cause/Create"))
        $("#liCause").addClass("active");
    else if (pathname.includes("/Admin/AdvertSubscription" || "/Admin/AdvertSubscription/Create"))
        $("#liAdvertSubscription").addClass("active");
    else if (pathname.includes("/Admin/Advert" || "/Admin/Advert/Create"))
        $("#liAdvert").addClass("active");

    $("#submitadvert").click(function () {
        var IsError = "";
        if ($('#VideoRate').val() == "" || $('#VideoRate').next('span').html() != "") {
            $('#VideoRate').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#VideoTotal').val() == "" || $('#VideoTotal').next('span').html() != "") {
            $('#VideoTotal').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#ImageRate').val() == "" || $('#ImageRate').next('span').html() != "") {
            $('#ImageRate').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#ImageTotal').val() == "" || $('#ImageTotal').next('span').html() != "") {
            $('#ImageTotal').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#PerClick').val() == "" || $('#PerClick').next('span').html() != "") {
            $('#PerClick').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#PercentageToCharity').val() == "" || $('#PercentageToCharity').next('span').html() != "") {
            $('#PercentageToCharity').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if (IsError.length > 0) {

            return false;
        }
        else {
            return true;
        }
    })

    $("#SubmitAdverts").click(function () {
        var IsError = "";
        if ($('#TotalAmount').val() == "" || $('#TotalAmount').next('span').html() != "") {
            $('#TotalAmount').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }
        if ($('#PaymentStaus').val() == "" || $('#PaymentStaus').next('span').html() != "") {
            $('#PaymentStaus').next('span').html("Please enter a valid number.");
            IsError = 'true';
        }

        if (IsError.length > 0) {

            return false;
        }
        else {
            return true;
        }
    });
    $("#SubmitCharity").click(function () {
        var IsError = "";
        if ($('#Name').val() == "" || $('#Name').next('span').html() != "") {
            $('#Name').next('span').html("This field is required.");
            IsError = 'true';
        }
        if (IsError.length > 0) {

            return false;
        }
        else {
            return true;
        }
    });


});
function pagevalue() {
    $("#btnSearch").click();
}
function validatedecimals() {
    $(".valid").on("change", function () {
        var filter = /^(0|-?\d{0,16}(\.\d{0,2})?)$/;
        if (!filter.test($(this).val())) {
            $(this).next('span').html("Please enter a valid number.");
        }
        else {
            $(this).next("span").html('');
        }
    });
}

function validinputs() {
    $(".validation").on("change", function () {
        if (!($(this).val())) {
            $(this).next('span').html("This field is required.");
        }
        else {
            $(this).next("span").html('');
        }
    });
}