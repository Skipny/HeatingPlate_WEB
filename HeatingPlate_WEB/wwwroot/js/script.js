// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showHide(obj) {

    if (obj == 'rbtnShowButton') {
        document.getElementById('<%=button1.ClientID %>').style.display = '';

    } else if (obj == 'rbtnHideButton') {
        document.getElementById('<%=button1.ClientID %>').style.display = 'none';
    }
}

