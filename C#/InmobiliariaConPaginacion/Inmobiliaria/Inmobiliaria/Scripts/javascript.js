function visibleVPrecioMax() {
    var vPrecioMax = document.getElementById("validPrecioMax");
    var precioMax = document.getElementById("LeftColumnContent_Buscador1_txtPrecioMax");
    if (precioMax.value == "" || !isNaN(precioMax.value)) {
        vPrecioMax.style.visibility = "hidden";
    }
    else {
        vPrecioMax.style.visibility = "visible";
    }
}

function visibleVPrecioMin() {
    var vPrecioMin = document.getElementById("validPrecioMin");
    var PrecioMin = document.getElementById("LeftColumnContent_Buscador1_txtPrecioMin");
    if (PrecioMin.value == "" || !isNaN(PrecioMin.value)) {
        vPrecioMin.style.visibility = "hidden";
    }
    else {
        vPrecioMin.style.visibility = "visible";
    }
}

function visibleVBaños() {
    var vBaños = document.getElementById("validBaños");
    var baños = document.getElementById("LeftColumnContent_Buscador1_txtBaños");
    if (baños.value == "" || !isNaN(baños.value)) {
        vBaños.style.visibility = "hidden";
    }
    else {
        vBaños.style.visibility = "visible";
    }
}

function operacion() {
    var op = document.getElementById("LeftColumnContent_Buscador1_listOperacion");
    var vOperacion = document.getElementById("validOperacion");
    if (op.value == "---Seleccionar---") {
        vOperacion.style.visibility = "visible";
    }
    else {
        vOperacion.style.visibility = "hidden";
    }
}


function myFunction() {
    var baños = document.getElementById("LeftColumnContent_Buscador1_txtBaños");
    var precioMax = document.getElementById("LeftColumnContent_Buscador1_txtPrecioMax");
    var precioMin = document.getElementById("LeftColumnContent_Buscador1_txtPrecioMin");
    var op = document.getElementById("LeftColumnContent_Buscador1_listOperacion");
    var btn = document.getElementById("LeftColumnContent_Buscador1_btnBuscar");

    visibleVPrecioMax();
    visibleVPrecioMin();
    visibleVBaños();
    operacion();

    if (!(baños.value == "" || !isNaN(baños.value)) || !(precioMax.value == "" || !isNaN(precioMax.value)) || !(precioMin.value == "" || !isNaN(precioMin.value)) || (op.value == "---Seleccionar---")) {
        btn.setAttribute("disabled", "disabled");
    }
    else {
        btn.removeAttribute("disabled");
    }
}


