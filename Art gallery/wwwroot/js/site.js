// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function GetImg(category) {
    $.ajax({
        type: "POST",
        url: "/Main/LoadImeges",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: '{category:"' + category + '"}',
        success: function (result) {
            alert(result.d);
            console.log(result);
        },
        error: function () {
            alert("Error while calling the server!");
        }
    });
}
