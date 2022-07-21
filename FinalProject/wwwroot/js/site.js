// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function drawGameBoard() {
    var canvas = document.getElementById("myCanvas");
    var ctx = canvas.getContext("2d");
    ctx.beginPath();
    ctx.rect(0, 0, 100, 100);
    ctx.rect(0, 100, 100, 100);
    ctx.rect(0, 200, 100, 100);
    ctx.rect(0, 300, 100, 100);
    ctx.rect(100, 0, 100, 100);
    ctx.rect(100, 100, 100, 100);
    ctx.rect(100, 200, 100, 100);
    ctx.rect(100, 300, 100, 100);
    ctx.rect(200, 0, 100, 100);
    ctx.rect(200, 100, 100, 100);
    ctx.rect(200, 200, 100, 100);
    ctx.rect(200, 300, 100, 100);
    ctx.rect(300, 0, 100, 100);
    ctx.rect(300, 100, 100, 100);
    ctx.rect(300, 200, 100, 100);
    ctx.rect(300, 300, 100, 100);
    ctx.stroke();
}