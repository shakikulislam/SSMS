


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
    
    var productTd = "<td> <input type='hidden' id='ProductName" + index + "'  name='PurchaseDetailses[" + index + "].ProductName' value='" + selectedItem.ProductName + "' /> " + selectedItem.ProductName + " </td>";
    var availableTd = "<td> <input type='hidden' id='AvailableQuantity" + index + "'  name='PurchaseDetailses[" + index + "].AvailableQuantity' value='" + selectedItem.AvailableQuantity + "' /> " + selectedItem.AvailableQuantity + " </td>";
    var qtyTd = "<td> <input type='hidden' id='Qty" + index + "'  name='PurchaseDetailses[" + index + "].Qty' value='" + selectedItem.Qty + "' /> " + selectedItem.Qty + " </td>";
    var priceTd = "<td> <input type='hidden' id='UnitPrice" + index + "'  name='PurchaseDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' /> " + selectedItem.UnitPrice + " </td>";

    var totalTd = "<td> <input type='hidden' id='TotalPrice" + index + "'  name='PurchaseDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "' /> " + selectedItem.TotalPrice + " </td>";

    var newRow = "<tr>" + indexTd + slTd + productTd + availableTd + qtyTd + priceTd + totalTd + " </tr>";

   

    $("#PurchaseDetailsTable").append(newRow);
    $("#ProductName").val("");
    $("#AvailableQuantity").val("");
    $("#Qty").val("");
    $("#UnitPrice").val("");
    
    document.getElementById("grandTotal").innerHTML = grandTotal;


}

var grandTotal=0;
function getSelectedItem() {
    var productName = $("#ProductName").val();
    var availableQuantity = $("#AvailableQuantity").val();
    var quantity = $("#Qty").val();
    var unitPrice = $("#UnitPrice").val();
    var totalPrice = quantity * unitPrice;
     grandTotal = grandTotal + totalPrice;
    var item = {
        "ProductName": productName,
        "AvailableQuantity": availableQuantity,
        "Qty": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice
    };




    return item;
}