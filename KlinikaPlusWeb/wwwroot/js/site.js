// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


nalazPopup = (url, title) =>{
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#nalazModal  .modal-body").html(res);
            $("#nalazModal  .modal-title").html(title);
            $("#nalazModal").modal("show");
        }
    })
}