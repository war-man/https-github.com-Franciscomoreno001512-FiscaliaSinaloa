var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {
























//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '1'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1607, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
if( EvaluaQuery("Select 'GLOBAL[Phase]'",rowIndex, nameOfTable)==EvaluaQuery("Select '2'",rowIndex, nameOfTable) ) {} else {}


}
//BusinessRuleId:1609, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2019, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 DisabledControl($("#" + nameOfTable + "Fecha_de_Solicitud" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_Solicitud' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_de_Solicitud" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_Solicitud' + rowIndex));}DisabledControl($("#" + nameOfTable + "Usuario_que_Solicita" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Solicita' + rowIndex));}DisabledControl($("#" + nameOfTable + "Origen" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Origen' + rowIndex));}DisabledControl($("#" + nameOfTable + "Expediente_Atencion_Temprana" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Expediente_Atencion_Temprana' + rowIndex));}DisabledControl($("#" + nameOfTable + "Expediente_Mecanismos_Alternos" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Expediente_Mecanismos_Alternos' + rowIndex));}DisabledControl($("#" + nameOfTable + "Carpeta_de_Investigacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Carpeta_de_Investigacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Forma_de_Invitacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Forma_de_Invitacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Numero_de_Invitacion" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Numero_de_Invitacion' + rowIndex));}DisabledControl($("#" + nameOfTable + "Fecha_de_la_cita" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Fecha_de_la_cita' + rowIndex));}DisabledControl($("#" + nameOfTable + "Hora_de_la_Cita" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Hora_de_la_Cita' + rowIndex));}DisabledControl($("#" + nameOfTable + "Estatus" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Estatus' + rowIndex));}DisabledControl($("#" + nameOfTable + "Lugar_de_la_Cita" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Lugar_de_la_Cita' + rowIndex));} SetNotRequiredToControl( $('#' + nameOfTable + 'Incidente_en_la_Recepcion' + rowIndex));SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo' + rowIndex));


}
//BusinessRuleId:2019, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//BusinessRuleId:2020, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'Update'){
if( $('#' + nameOfTable + 'Estatus' + rowIndex).val()==TryParseInt('1', '1') && $('#' + nameOfTable + 'Resultado' + rowIndex).val()!=TryParseInt('null', 'null') && $('#' + nameOfTable + 'Expediente_Mecanismos_Alternos' + rowIndex).val()!=TryParseInt('null', 'null') ) { EvaluaQuery("  update Solicitud_de_Notificacion"
+"  set Estatus=2"
+"  where Folio=FLDD[lblFolio]", rowIndex, nameOfTable); SendEmailQuery('SAPROJ - Solicitud de Invitación Atendida', EvaluaQuery("select Email from Spartan_User where Id_User=FLD[Usuario_que_Solicita]"), "Por este medio se le informa que la invitación no. <b>FLD[Numero_de_Invitacion]</b> del expediente No. <b>FLDD[Expediente_Mecanismos_Alternos]</b> ha sido atendida."
+" "
+" <br><br>"
+" "
+" <b>Resultado:</b> FLDD[Resultado]",rowIndex,nameOfTable);} else {}


}
//BusinessRuleId:2020, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}

function EjecutarValidacionesAntesDeGuardarMRDetalle_de_Invitado_de_Notificacion(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_de_Invitado_de_Notificacion//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRDetalle_de_Invitado_de_Notificacion(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_de_Invitado_de_Notificacion//
}
function EjecutarValidacionesAlEliminarMRDetalle_de_Invitado_de_Notificacion(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Detalle_de_Invitado_de_Notificacion//
    return result;
}
function EjecutarValidacionesNewRowMRDetalle_de_Invitado_de_Notificacion(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Detalle_de_Invitado_de_Notificacion//
    return result;
}
function EjecutarValidacionesEditRowMRDetalle_de_Invitado_de_Notificacion(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_EDITROWMR_Detalle_de_Invitado_de_Notificacion//
    return result;
}

