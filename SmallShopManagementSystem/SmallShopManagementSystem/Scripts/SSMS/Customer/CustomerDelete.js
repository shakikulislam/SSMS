
function myFunction() {
    var txt;
    var r = confirm("Press a button!\nEither OK or Cancel.\n Do You Want To Delete ?");
    if (r == true) {
        txt = "You pressed OK!";
    } else {
        txt = "You pressed Cancel!";
    }
    document.getElementById("demo").innerHTML = txt;
}