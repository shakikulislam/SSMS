var subDirectory = "../../";

$("#ShowPv").click(function () {
    var url = subDirectory + "Categories/GetCategoriePv";
    $.post(url, function(rData) {
        $("#CategorieViewPv").html(rData);
    });


});