﻿var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_de_Galeria_de_Intervinientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_de_Galeria_de_Intervinientes//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Galeria_de_Intervinientes(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_de_Galeria_de_Intervinientes//
}
function EjecutarValidacionesAlEliminarMRDetalle_de_Galeria_de_Intervinientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_de_Galeria_de_Intervinientes//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_de_Galeria_de_Intervinientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_de_Galeria_de_Intervinientes//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_de_Galeria_de_Intervinientes(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_de_Galeria_de_Intervinientes//
    return result;
}

