$(document).ready(function () {
    jQuery.fn.carousel.Constructor.TRANSITION_DURATION = 200  // 2 seconds
});

$(document).ready(function () {
    $.ajax('/api/Order',   // request url
        {
            success: function (data, status, xhr) {// success callback function
                $('#cart').text(data.count);
            }
        });
});