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

    $.post({
        url: "home/search/",
        data: {"nameFragment": input},
        success: function (result) {
            $('#content').html(result);
        }
    });
}