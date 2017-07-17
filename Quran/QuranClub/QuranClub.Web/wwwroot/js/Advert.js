
$(function () {
    $("#drpAdvretLanguages").change(function () {
        var languages = ""
        $("#drpAdvretLanguages").next("div").find("ul.multiselect-container li").each(function (index) {
            if ($(this).hasClass("active")) {
                var checkboxVal = $(this).find("a label.checkbox .checker input[type=checkbox]").val();
                languages = languages + checkboxVal + ",";
            }
        });
        $("#hdnAdvretLanguages").val(languages.substring(0, languages.length - 1))
    });

    if ($("#hdnAdvretLanguages").val() != '') {
        var languages = $("#hdnAdvretLanguages").val().split(",")
        $.each(languages, function (key, value) {
            $("#drpAdvretLanguages").next("div").find("ul.multiselect-container li").each(function (index) {
                var checkboxVal = $(this).find("a label.checkbox .checker input[type=checkbox]").val()
                if (checkboxVal == value) {
                    $(this).addClass("active");
                    $(this).find("a label.checkbox .checker input[type=checkbox]").click();
                }
            });
        })

    }

    //On Country selection
    $("#drpAdvretCountries").change(function () {
        var Countries = "";
        $("#drpAdvretCountries").next("div").find("ul.multiselect-container li").each(function (index) {
            if ($(this).hasClass("active")) {
                var checkboxVal = $(this).find("a label.checkbox .checker input[type=checkbox]").val();
                Countries = Countries + checkboxVal + ",";
            }
        });
        $("#hdnAdvretCountries").val(Countries.substring(0, Countries.length - 1))
    })

    $("#drpcities").change(function () {
        var Cities = "";
        $("#drpcities").next("div").find("ul.multiselect-container li").each(function (index) {
            if ($(this).hasClass("active")) {
                var checkboxVal = $(this).find("a label.checkbox .checker input[type=checkbox]").val();
                Cities = Cities + checkboxVal + ",";
                $(this).find("a label.checkbox .checker").find("span").addClass("checked");
            }
            else {
                $(this).find("a label.checkbox .checker").find("span").removeClass("checked");
            }
        });
        $("#hdnAdvretCities").val(Cities.substring(0, Cities.length - 1))
    })
});

function Dropdownchange(value, url, AppendValue) {

    var array = $("#hdnAdvretCountries").val().split(",");
    var Cid = new Array();
    $.each(array, function (i) {
        Cid.push(array[i]);
    })
    $.ajax({
        url: url,
        type: 'POST',
        data: { Id: Cid },
        dataType: 'html',

        success: function (data) {
            $(AppendValue).html("");
            $(AppendValue).html(data);
            $(AppendValue).multiselect('destroy');
            $(AppendValue).multiselect();

            $("#drpcities").next("div").find("ul.multiselect-container li").each(function (index) {
                $("<div class='checker'></div>").appendTo($(this).find("a label.checkbox"));
                $("<span class=''></span>").appendTo($(this).find("a label.checkbox .checker"));
                $(this).find("a label.checkbox  input[type=checkbox]").appendTo($(this).find("a label.checkbox .checker").find("span"))
            })
        },
        complete: function () {
            if ($("#hdnAdvretCities").val() != '') {
                var cities = $("#hdnAdvretCities").val().split(",")
                $.each(cities, function (key, value) {
                    $("#drpcities").next("div").find("ul.multiselect-container li").each(function (index) {
                        var checkboxVal = $(this).find("a label.checkbox .checker input[type=checkbox]").val();
                        if (checkboxVal == value) {
                            $(this).addClass("active");
                            $(this).find("a label.checkbox .checker input[type=checkbox]").click();
                        }
                    });
                })
            }
        }
    });
}

//$("#drpAdvretCountries").next("div").on("hide.bs.dropdown", function (event) {
//});
//function OnBegin() {
//    $('#LoadingElementId').show();

//}