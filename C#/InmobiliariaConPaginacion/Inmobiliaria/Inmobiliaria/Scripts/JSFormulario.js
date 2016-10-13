function visibleApto() {
    var a = document.getElementById("MainContent_FormularioInmueble1_listCasaOApto");
    var divApto = document.getElementById("divApto");
    if (a.value == "Apartamento") {
        divApto.style.visibility = "visible";
    }
    else {
        divApto.style.visibility = "hidden";
    }
}

function visibleVenta() {
    var b = document.getElementById("MainContent_FormularioInmueble1_chkVenta");
    var divLblVenta = document.getElementById("divLblVenta");
    var divTxtPrecioVenta = document.getElementById("divTxtPrecioVenta");
    if (b.checked) {
        divLblVenta.style.visibility = "visible";
        divTxtPrecioVenta.style.visibility = "visible";
    }
    else {
        divLblVenta.style.visibility = "hidden";
        divTxtPrecioVenta.style.visibility = "hidden";
    }
}

function visibleAlquiler() {
    var c = document.getElementById("MainContent_FormularioInmueble1_chkAlquiler");
    var divLblAlquiler = document.getElementById("divLblAlquiler");
    var divTxtPrecioAlquiler = document.getElementById("divTxtPrecioAlquiler");
    if (c.checked) {
        divLblAlquiler.style.visibility = "visible";
        divTxtPrecioAlquiler.style.visibility = "visible";
    }
    else {
        divLblAlquiler.style.visibility = "hidden";
        divTxtPrecioAlquiler.style.visibility = "hidden";
    }
}

function visibleValidDormitorios() {
    var d = document.getElementById("MainContent_FormularioInmueble1_txtdormitorios");
    var vDormitorios = document.getElementById("validDormitorios");
    if (isNaN(d.value) || d.value == "") {
        vDormitorios.style.visibility = "visible";
    }
    else {
        vDormitorios.style.visibility = "hidden";
    }
}

function visibleValidBaños() {
    var d = document.getElementById("MainContent_FormularioInmueble1_txtBaños");
    var vBaños = document.getElementById("validBaños");
    if (isNaN(d.value) || d.value == "") {
        vBaños.style.visibility = "visible";
    }
    else {
        vBaños.style.visibility = "hidden";
    }
}

function visibleValidInmueble() {
    var a = document.getElementById("MainContent_FormularioInmueble1_listCasaOApto");
    var x = document.getElementById("validTipoInmueble");
    if (a.value == "---Seleccionar---") {
        x.style.visibility = "visible";
    }
    else {
        x.style.visibility = "hidden";
    }
}

function visibleValidOperacion() {
    var b = document.getElementById("MainContent_FormularioInmueble1_chkVenta");
    var c = document.getElementById("MainContent_FormularioInmueble1_chkAlquiler");
    var y = document.getElementById("validOperacion");
    if (!(b.checked) && !(c.checked)) {
        y.style.visibility = "visible";
    }
    else {
        y.style.visibility = "hidden";
    }
}

function visibleWarningPiso() {
    var a = document.getElementById("MainContent_FormularioInmueble1_listCasaOApto");
    var b = document.getElementById("MainContent_FormularioInmueble1_txtPiso");
    var x = document.getElementById("divWarningPiso");
    if (a.value != "Apartamento") {
        x.style.visibility = "hidden";
    }
    else {
        if ((!isNaN(b.value)) && !(b.value == "")) {
            x.style.visibility = "hidden";
        }
        else {
            x.style.visibility = "visible";
        }
    }
}

function visibleWarningVenta() {
    var a = document.getElementById("MainContent_FormularioInmueble1_chkVenta");
    var div = document.getElementById("divWarningVenta");
    var txt = document.getElementById("MainContent_FormularioInmueble1_txtPrecioVenta");
    if (!(a.checked)) {
        div.style.visibility = "hidden";
    }
    else {
        if ((!isNaN(txt.value)) && !(txt.value == "")) {
            div.style.visibility = "hidden";
        }
        else {
            div.style.visibility = "visible";
        }
    }
}

function visibleWarningAlquiler() {
    var a = document.getElementById("MainContent_FormularioInmueble1_chkAlquiler");
    var div = document.getElementById("divWarningAlquiler");
    var txt = document.getElementById("MainContent_FormularioInmueble1_txtPrecioAlquiler");
    if (!(a.checked)) {
        div.style.visibility = "hidden";
    }
    else {
        if ((!isNaN(txt.value)) && !(txt.value == "")) {
            div.style.visibility = "hidden";
        }
        else {
            div.style.visibility = "visible";
        }
    }
}

function visibleWarningBarrio() {
    var g = document.getElementById("MainContent_FormularioInmueble1_listBarrios");
    var barrio = document.getElementById("validBarrio");
    if (g.value == "---Seleccionar---") {
        barrio.style.visibility = "visible";
    }
    else {
        barrio.style.visibility = "hidden";
    }
}

function myFunction() {

    // Elementos con los cuales trabajar
    var a = document.getElementById("MainContent_FormularioInmueble1_listCasaOApto");
    var b = document.getElementById("MainContent_FormularioInmueble1_chkVenta");
    var c = document.getElementById("MainContent_FormularioInmueble1_chkAlquiler");
    var d = document.getElementById("MainContent_FormularioInmueble1_txtdormitorios");
    var f = document.getElementById("MainContent_FormularioInmueble1_txtBaños");
    var btnI = document.getElementById("MainContent_FormularioInmueble1_btnIngresar");
    var btnM = document.getElementById("MainContent_FormularioInmueble1_btnModificar");
    var e = document.getElementById("MainContent_FormularioInmueble1_txtPiso");
    var x = document.getElementById("divWarningPiso");
    var y = document.getElementById("divWarningVenta");
    var z = document.getElementById("divWarningAlquiler");
    var g = document.getElementById("MainContent_FormularioInmueble1_listBarrios");
    var w = document.getElementById("validBarrio");


    // Hacer visibles o no algunas partes del formulario
    visibleApto();
    visibleVenta();
    visibleAlquiler();
    visibleValidDormitorios();
    visibleValidBaños();
    visibleValidInmueble();
    visibleValidOperacion();
    visibleWarningPiso();
    visibleWarningVenta();
    visibleWarningAlquiler();
    visibleWarningBarrio();


    //Validaciones        
    if (!(a.value == "---Seleccionar---") && !(!(b.checked) && !(c.checked)) && (!isNaN(d.value)) && !(d.value == "") && (!isNaN(f.value)) && !(f.value == "") && !(g.value == "---Seleccionar---")) {
        if (x.style.visibility == "visible") {
            btnI.setAttribute("disabled", "disabled");
            btnM.setAttribute("disabled", "disabled");
        }
        else if (y.style.visibility == "visible") {
            btnI.setAttribute("disabled", "disabled");
            btnM.setAttribute("disabled", "disabled");
        }
        else if (z.style.visibility == "visible") {
            btnI.setAttribute("disabled", "disabled");
            btnM.setAttribute("disabled", "disabled");
        }
        else {
            btnI.removeAttribute("disabled");
            btnM.removeAttribute("disabled");
        }
    }
    else {
        btnI.setAttribute("disabled", "disabled");
        btnM.setAttribute("disabled", "disabled");
    }
}

