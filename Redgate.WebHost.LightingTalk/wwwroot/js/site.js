// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function GetItem() {
    $.ajax({
        type: "GET",
        url: "/api/Items/",
        success: function (data) {
            $("#result").text(data);
        },
        error: function (data) {
            if (data.status === 401) {
                $("#result").text("User not Logged In");
            }
            else if (data.status === 403) {
                $("#result").text("User not Authorized");
            } else {
                $("#result").text(data.responseText);
            }
        }
    });
}

function AddItem() {
    var name = $("#documentName")[0].value;
    debugger;
    $.ajax({
        type: "Post",
        url: "/api/Items/Add",
        success: function (data) {
            $("#result").text(data);
        },
        data: JSON.stringify(name),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        error: function (data) {
            if (data.status === 401) {
                $("#result").text("User not Logged In");
            }
            else if (data.status === 403) {
                $("#result").text("User not Authorized");
            } else {
                $("#result").text(data.responseText);
            }
        }
    });
    document.getElementById("documentName").value = "";
}

