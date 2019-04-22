
$(document).ready(function () {

    $("#ProductName").change(function () {

        var selectedItemDesc2 = $("#ProductName option:selected").attr("data-desc2");
        $("#AvailableQuantity").val(selectedItemDesc2);

    });

});