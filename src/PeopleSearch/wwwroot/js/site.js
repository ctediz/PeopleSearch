// Write your Javascript code.

// Index view
$("#srch-term").keyup(function (event) {
    if (event.keyCode == 13) {
        search();
    }
});

function search() {
    // Search
    var input = $('#srch-term').val();

    $.ajax({
        url: "home/search", success: function (result) {
            $('#content').html(result);
        }
    });
}