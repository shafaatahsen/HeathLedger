// Write your Javascript code.
$('.message a').click(function () {
    $('form').animate({ height: "toggle", opacity: "toggle" }, "slow");
});

function buttonclick() {
    var string = "<%=Name%>";
    document.writeln(string);


}  
