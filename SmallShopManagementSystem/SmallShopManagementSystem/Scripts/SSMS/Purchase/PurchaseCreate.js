﻿


$("#AddButton").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var productCell = "<td> <input type='hidden' id='IdProduct" + index + "'  name='PurchaseDetailses[" + index + "].ProductCode' value='" + selectedItem.IdProduct + "' /> " + selectedItem.IdProduct + " </td>";
    //var codeCell = "<td> <input type='hidden' id='ProductCode" + index + "'  name='PurchaseDetailses[" + index + "].Code' value='" + selectedItem.ProductCode + "' /> " + selectedItem.ProductCode + " </td>";
    var manufacturedDateCell = "<td> <input type='hidden' id='ProductManufacturedDate" + index + "'  name='PurchaseDetailses[" + index + "].ManufacturedDate' value='" + selectedItem.ProductManufacturedDate + "' /> " + selectedItem.ProductManufacturedDate + " </td>";
    var expireDateCell = "<td> <input type='hidden' id='ProductExpireDate" + index + "'  name='PurchaseDetailses[" + index + "].ExpireDate' value='" + selectedItem.ProductExpireDate + "' /> " + selectedItem.ProductExpireDate + " </td>";
    var quantityCell = "<td> <input type='hidden' id='ProductQuantity" + index + "'  name='PurchaseDetailses[" + index + "].Quantity' value='" + selectedItem.ProductQuantity + "' /> " + selectedItem.ProductQuantity + " </td>";
    var unitPriceCell = "<td> <input type='hidden' id='ProductUnitPrice" + index + "'  name='PurchaseDetailses[" + index + "].UnitPrice' value='" + selectedItem.ProductUnitPrice + "' /> " + selectedItem.ProductUnitPrice + " </td>";
    var totalPriceCell = "<td> <input type='hidden' id='ProductTotalPrice" + index + "'  name='PurchaseDetailses[" + index + "].TotalPrice' value='" + selectedItem.ProductTotalPrice + "' /> " + selectedItem.ProductTotalPrice + " </td>";
    var previousCostPriceCell = "<td> <input type='hidden' id='ProductPreviousCostPrice" + index + "'  name='PurchaseDetailses[" + index + "].PreviousCostPrice' value='" + selectedItem.ProductPreviousCostPrice + "' /> " + selectedItem.ProductPreviousCostPrice + " </td>";
    var previousMrpCell = "<td> <input type='hidden' id='ProductPreviousMrp" + index + "'  name='PurchaseDetailses[" + index + "].PreviousMrp' value='" + selectedItem.ProductPreviousMrp + "' /> " + selectedItem.ProductPreviousMrp + " </td>";
    var newCostPriceCell = "<td> <input type='hidden' id='ProductNewCostPrice" + index + "'  name='PurchaseDetailses[" + index + "].NewCostPrice' value='" + selectedItem.ProductNewCostPrice + "' /> " + selectedItem.ProductNewCostPrice + " </td>";
    var newMrpCell = "<td> <input type='hidden' id='ProductNewMrp" + index + "'  name='PurchaseDetailses[" + index + "].NewMrp' value='" + selectedItem.ProductNewMrp + "' /> " + selectedItem.ProductNewMrp + " </td>";



    var newRow = "<tr>" + indexTd + slTd + productCell + manufacturedDateCell + expireDateCell + quantityCell + unitPriceCell + totalPriceCell + previousCostPriceCell + previousMrpCell + newCostPriceCell + newMrpCell + " </tr>";

    $("#PurchaseDetailsTable").append(newRow);
    $("#IdProduct").val("");
    //$("#ProductCode").val("");
    $("#ProductManufacturedDate").val("");
    $("#ProductExpireDate").val("");
    $("#ProductQuantity").val("");
    $("#ProductUnitPrice").val("");
    $("#ProductTotalPrice").val("");
    $("#ProductPreviousCostPrice").val("");
    $("#ProductPreviousMrp").val("");
    $("#ProductNewCostPrice").val("");
    $("#ProductNewMrp").val("");

  
}


function getSelectedItem() {
    var idProduct = $("#IdProduct").val();
    //var productCode = $("#ProductCode").val();
    var productManufacturedDate = $("#ProductManufacturedDate").val();
    var productExpireDate = $("#ProductExpireDate").val();
    var productQuantity = $("#ProductQuantity").val();
    var productUnitPrice = $("#ProductUnitPrice").val();
    var productTotalPrice = productQuantity * productUnitPrice;
    var productPreviousCostPrice = $("#ProductPreviousCostPrice").val();
    var productPreviousMrp = $("#ProductPreviousMrp").val();
    var productNewCostPrice = productUnitPrice;
    //var productNewMrp = $("#ProductNewMrp").val();
    var productNewMrp = (productUnitPrice / 100) * 25;


    var item = {
        "IdProduct": idProduct,
        //"ProductCode": productCode,
        "ProductManufacturedDate": productManufacturedDate,
        "ProductExpireDate": productExpireDate,
        "ProductQuantity": productQuantity,
        "ProductUnitPrice": productUnitPrice,
        "ProductTotalPrice": productTotalPrice,
        "ProductPreviousCostPrice": productPreviousCostPrice,
        "ProductPreviousMrp": productPreviousMrp,
        "ProductNewCostPrice": productNewCostPrice,
        "ProductNewMrp": productNewMrp



    };


    //$("#ProductQuantity,#ProductUnitPrice").keyup(function () {
    //    $('#ProductTotalPrice').val($('#ProductQuantity').val() * $('#ProductUnitPrice').val());
    //});


   
    //$(function () {
    //    $("#ProductUnitPrice").change(function () { // input on change
    //        var result = parseFloat(parseInt($("#ProductUnitPrice").val(), 10)*25) / parseInt($("#ProductUnitPrice").val(), 10);
    //        $('#ProductTotalPrice').val(result || ''); //shows value in "#rate"
    //    })
    //});

    


    return item;
}