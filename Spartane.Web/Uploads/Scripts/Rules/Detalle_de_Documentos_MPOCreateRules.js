var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
var saltarValidacion = false;
$(document).ready(function () {
//NEWBUSINESSRULE_NONE//
});
function EjecutarValidacionesAlComienzo() {

//BusinessRuleId:2024, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Fecha' + rowIndex),EvaluaQuery(" select convert (varchar(11),getdate(),105)", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Hora' + rowIndex),EvaluaQuery(" select convert (varchar(8),getdate(),108)"
+" ", rowIndex, nameOfTable)); AsignarValor($('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex),EvaluaQuery("select name from spartan_user where id_user = GLOBAL[USERID]", rowIndex, nameOfTable));


}
//BusinessRuleId:2024, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));$('#divModulo_Atencion_Inicial').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo_Atencion_Inicial' + rowIndex));$('#divArchivo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));} DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));}


}
//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));$('#divModulo_Atencion_Inicial').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo_Atencion_Inicial' + rowIndex));$('#divArchivo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));} DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));}


}
//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 $('#divClave').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Clave' + rowIndex));$('#divModulo_Atencion_Inicial').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Modulo_Atencion_Inicial' + rowIndex));$('#divArchivo').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo' + rowIndex)); DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));} DisabledControl($("#" + nameOfTable + "Usuario_que_Registra" + rowIndex), ("true" == "true"));if ('true'=='true'){SetNotRequiredToControl( $('#' + nameOfTable + 'Usuario_que_Registra' + rowIndex));}


}
//BusinessRuleId:2023, Attribute:0, Operation:Object, Event:SCREENOPENING







//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_Adjunto' + rowIndex));

}
//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_Adjunto' + rowIndex));

}
//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Archivo_Adjunto' + rowIndex));

}
//BusinessRuleId:2065, Attribute:0, Operation:Object, Event:SCREENOPENING





//BusinessRuleId:2156, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Probable_Responsable' + rowIndex));

}
//BusinessRuleId:2156, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2156, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 SetNotRequiredToControl( $('#' + nameOfTable + 'Probable_Responsable' + rowIndex));

}
//BusinessRuleId:2156, Attribute:0, Operation:Object, Event:SCREENOPENING



//BusinessRuleId:2183, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 AsignarValor($('#' + nameOfTable + 'Modulo_Atencion_Inicial' + rowIndex),EvaluaQuery(" SELECT NUAT FROM Modulo_Atencion_Inicial WHERE Clave = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable));

}
//BusinessRuleId:2183, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2311, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("SELECT COUNT(Clave) FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]	",rowIndex, nameOfTable)!=TryParseInt('0', '0') ) { var valor = $('#' + nameOfTable + 'Involucrado' + rowIndex).val();   $('#' + nameOfTable + 'Involucrado' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Involucrado' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Involucrado' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE_COMPLETO FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Involucrado' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE_COMPLETO FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Involucrado' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Involucrado' + rowIndex).val(valor).trigger('change'); $('#divInvolucrado').css('display', 'block');} else { $('#divInvolucrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Involucrado' + rowIndex));}

}
//BusinessRuleId:2311, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2311, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("SELECT COUNT(Clave) FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]	",rowIndex, nameOfTable)!=TryParseInt('0', '0') ) { var valor = $('#' + nameOfTable + 'Involucrado' + rowIndex).val();   $('#' + nameOfTable + 'Involucrado' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Involucrado' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Involucrado' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE_COMPLETO FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Involucrado' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT CLAVE, NOMBRE_COMPLETO FROM Detalle_de_Datos_Generales WHERE Modulo_Atencion_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Involucrado' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Involucrado' + rowIndex).val(valor).trigger('change'); $('#divInvolucrado').css('display', 'block');} else { $('#divInvolucrado').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Involucrado' + rowIndex));}

}
//BusinessRuleId:2311, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2312, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){


}
//BusinessRuleId:2312, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2312, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){


}
//BusinessRuleId:2312, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2313, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
if( EvaluaQuery("SELECT COUNT(CLAVE) FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]",rowIndex, nameOfTable)!=TryParseInt('0', '0') ) { var valor = $('#' + nameOfTable + 'Delito' + rowIndex).val();   $('#' + nameOfTable + 'Delito' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Delito' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Delito' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION_CORTA FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Delito' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION_CORTA FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Delito' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Delito' + rowIndex).val(valor).trigger('change'); if('false' == 'true')
{
	$('#divDelito').css('display', 'none');
}
else
{
	$('#divDelito').css('display', 'block');
}} else { if('true' == 'true')
{
	$('#divDelito').css('display', 'none');
}
else
{
	$('#divDelito').css('display', 'block');
}}

}
//BusinessRuleId:2313, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2313, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
if( EvaluaQuery("SELECT COUNT(CLAVE) FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]",rowIndex, nameOfTable)!=TryParseInt('0', '0') ) { var valor = $('#' + nameOfTable + 'Delito' + rowIndex).val();   $('#' + nameOfTable + 'Delito' + rowIndex).empty();         if(!$('#' + nameOfTable + 'Delito' + rowIndex).hasClass('AutoComplete'))  {         $('#' + nameOfTable + 'Delito' + rowIndex).append($("<option selected />").val("").text(""));         $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION_CORTA FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {           $('#' + nameOfTable + 'Delito' + rowIndex).append($("<option />").val(index).text(value));      });  }       else    {    var selectData = [];   selectData.push({id: "",text: "" });      $.each(EvaluaQueryDictionary("SELECT CLAVE, DESCRIPCION_CORTA FROM Detalle_de_Delito WHERE Expediente_Inicial = GLOBAL[SpartanOperationId]", rowIndex, nameOfTable), function (index, value) {            selectData.push({              id: index,              text: value          });    });      $('#' + nameOfTable + 'Delito' + rowIndex).select2({data: selectData})    }   $('#' + nameOfTable + 'Delito' + rowIndex).val(valor).trigger('change'); if('false' == 'true')
{
	$('#divDelito').css('display', 'none');
}
else
{
	$('#divDelito').css('display', 'block');
}} else { if('true' == 'true')
{
	$('#divDelito').css('display', 'none');
}
else
{
	$('#divDelito').css('display', 'block');
}}

}
//BusinessRuleId:2313, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'New'){
 $('#divTipo_de_Documento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex));

}
//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Update'){
 $('#divTipo_de_Documento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex));

}
//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING

//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING
if(operation == 'Consult'){
 $('#divTipo_de_Documento').css('display', 'none'); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex)); SetNotRequiredToControl( $('#' + nameOfTable + 'Tipo_de_Documento' + rowIndex));

}
//BusinessRuleId:2611, Attribute:0, Operation:Object, Event:SCREENOPENING

//NEWBUSINESSRULE_SCREENOPENING//
}
function EjecutarValidacionesAntesDeGuardar(){
	var result = true;
//NEWBUSINESSRULE_BEFORESAVING//
    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//BusinessRuleId:1735, Attribute:2, Operation:Object, Event:AFTERSAVING
if(operation == 'New'){
 EvaluaQuery(" update Detalle_de_Documentos_MPO"
+" 	set Modulo_Atencion_Inicial= GLOBAL[SpartanOperationId]"
+" 	where Clave=GLOBAL[keyvalueinserted]", rowIndex, nameOfTable);


}
//BusinessRuleId:1735, Attribute:2, Operation:Object, Event:AFTERSAVING

//NEWBUSINESSRULE_AFTERSAVING//
}



function EjecutarValidacionesAntesDeGuardarMRDetalle_Involucrados_en_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Involucrados_en_Documentos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Involucrados_en_Documentos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Involucrados_en_Documentos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Involucrados_en_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Involucrados_en_Documentos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Involucrados_en_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Involucrados_en_Documentos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Involucrados_en_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Involucrados_en_Documentos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Probable_Responsable_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Probable_Responsable_de_Documentos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Probable_Responsable_de_Documentos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Probable_Responsable_de_Documentos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Probable_Responsable_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Probable_Responsable_de_Documentos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Probable_Responsable_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Probable_Responsable_de_Documentos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Probable_Responsable_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Probable_Responsable_de_Documentos// 
 return result; 
} 

function EjecutarValidacionesAntesDeGuardarMRDetalle_Delitos_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_BEFORESAVINGMR_Detalle_Delitos_de_Documentos// 
 return result; 
} 

function EjecutarValidacionesDespuesDeGuardarMRDetalle_Delitos_de_Documentos(nameOfTable, rowIndex){ 
//NEWBUSINESSRULE_AFTERSAVINGMR_Detalle_Delitos_de_Documentos// 
} 

function EjecutarValidacionesAlEliminarMRDetalle_Delitos_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_DELETEMR_Detalle_Delitos_de_Documentos// 
 return result; 
} 

function EjecutarValidacionesNewRowMRDetalle_Delitos_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_NEWROWMR_Detalle_Delitos_de_Documentos// 
  return result; 
} 

function EjecutarValidacionesEditRowMRDetalle_Delitos_de_Documentos(nameOfTable, rowIndex){ 
 var result= true; 
//NEWBUSINESSRULE_EDITROWMR_Detalle_Delitos_de_Documentos// 
 return result; 
} 
