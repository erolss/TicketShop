$(document).ready(function (e) {
    $('#search_submit').click(function (e) {
        e.preventDefault();
        $('#search_form').submit();
    });

    $.get("/Order/ItemsInCart", function (data) {
        $("#cart_badge").text(data);
    });

    $('.addToCartBtn').click(function (e) {
        e.preventDefault();
        var itemID = $(this).val();
        $.post("/Order/AddToCart", { "eventDateId": itemID }, function (data) {
            $("#cart_badge").text(data);
        });
    });

});