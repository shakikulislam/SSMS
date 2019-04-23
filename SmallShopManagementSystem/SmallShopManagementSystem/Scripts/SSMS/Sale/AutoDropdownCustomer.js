
$(document).ready(function () {

    $("#CustomerName").change(function () {

        var selectedItemDesc = $("#CustomerName option:selected").attr("data-desc");
        $("#txtProductDescription").val(selectedItemDesc);

    });

});