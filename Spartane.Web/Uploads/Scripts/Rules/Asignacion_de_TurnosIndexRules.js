var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {






//BusinessRuleId:1612, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('5', '5') || EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('4', '4')) {
 MRWhere=ReplaceQuery("Asignacion_de_Turnos.Folio in (select folio from Asignacion_de_Turnos where DATEDIFF(day, Fecha_de_Turno, GETDATE()) = 0)");} else {}


}
//BusinessRuleId:1516, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('5', '5') || EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('4', '4')) {
 MROrder=ReplaceQuery("Asignacion_de_Turnos.Urgencia DESC");} else {}


}





//NEWBUSINESSRULE_BEFORECREATIONLIST//
});

function EjecutarValidacionesDespuesDeCrearLista()
{
//BusinessRuleId:1515, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( EvaluaQuery("select GLOBAL[USERROLEID]",rowIndex, nameOfTable)==TryParseInt('5', '5') || EvaluaQuery("select GLOBAL[USERROLEID]	",rowIndex, nameOfTable)==TryParseInt('4', '4') ) { 
if('true' == 'true')
{
	table.column('Folio:name').visible(false)
}
else
{
	table.column('Folio:name').visible(true)
} 
if('true' == 'true')
{
	table.column('Apellido_Paterno:name').visible(false)
}
else
{
	table.column('Apellido_Paterno:name').visible(true)
}
if('true' == 'true')
{
	table.column('Nombres:name').visible(false)
}
else
{
	table.column('Nombres:name').visible(true)
}
if('true' == 'true')
{
	table.column('Apellido_Materno:name').visible(false)
}
else
{
	table.column('Apellido_Materno:name').visible(true)
}
if('true' == 'true')
{
	table.column('Motivo_Finalizacion_TurnoDescripcion:name').visible(false)
}
else
{
	table.column('Motivo_Finalizacion_TurnoDescripcion:name').visible(true)
}
if('true' == 'true')
{
	table.column('Fecha_de_Turno:name').visible(false)
}
else
{
	table.column('Fecha_de_Turno:name').visible(true)
} if('true' == 'true')
{
	table.column('Hora_de_Turno:name').visible(false)
}
else
{
	table.column('Hora_de_Turno:name').visible(true)
} if('true' == 'true')
{
	table.column('Unidad_de_AtencionDescripcion:name').visible(false)
}
else
{
	table.column('Unidad_de_AtencionDescripcion:name').visible(true)
} if('true' == 'true')
{
	table.column('RecepcionName:name').visible(false)
}
else
{
	table.column('RecepcionName:name').visible(true)
} if('true' == 'true')
{
	table.column('SexoDescripcion:name').visible(false)
}
else
{
	table.column('SexoDescripcion:name').visible(true)
} if('true' == 'true')
{
	table.column('Edad:name').visible(false)
}
else
{
	table.column('Edad:name').visible(true)
} if('true' == 'true')
{
	table.column('Tipo_de_IdentificacionNombre:name').visible(false)
}
else
{
	table.column('Tipo_de_IdentificacionNombre:name').visible(true)
} if('true' == 'true')
{
	table.column('Numero_de_Identificacion:name').visible(false)
}
else
{
	table.column('Numero_de_Identificacion:name').visible(true)
} if('true' == 'true')
{
	table.column('OrientadorName:name').visible(false)
}
else
{
	table.column('OrientadorName:name').visible(true)
} if('true' == 'true')
{
	table.column('Estatus_de_TurnoDescripcion:name').visible(false)
}
else
{
	table.column('Estatus_de_TurnoDescripcion:name').visible(true)
} if('true' == 'true')
{
	table.column('ModuloDescripcion:name').visible(false)
}
else
{
	table.column('ModuloDescripcion:name').visible(true)
} if('true' == 'true')
{
	table.column('Fecha_de_Asignacion:name').visible(false)
}
else
{
	table.column('Fecha_de_Asignacion:name').visible(true)
} if('true' == 'true')
{
	table.column('Hora_de_Asignacion:name').visible(false)
}
else
{
	table.column('Hora_de_Asignacion:name').visible(true)
} if('true' == 'true')
{
	table.column('Fecha_de_Finalizacion:name').visible(false)
}
else
{
	table.column('Fecha_de_Finalizacion:name').visible(true)
} if('true' == 'true')
{
	table.column('Hora_de_Finalizacion:name').visible(false)
}
else
{
	table.column('Hora_de_Finalizacion:name').visible(true)
}} else { if('false' == 'true')
{
	table.column('Folio:name').visible(false)
}
else
{
	table.column('Folio:name').visible(true)
} if('false' == 'true')
{
	table.column('Fecha_de_Turno:name').visible(false)
}
else
{
	table.column('Fecha_de_Turno:name').visible(true)
} if('false' == 'true')
{
	table.column('Hora_de_Turno:name').visible(false)
}
else
{
	table.column('Hora_de_Turno:name').visible(true)
} if('false' == 'true')
{
	table.column('Unidad_de_AtencionDescripcion:name').visible(false)
}
else
{
	table.column('Unidad_de_AtencionDescripcion:name').visible(true)
} if('false' == 'true')
{
	table.column('RecepcionName:name').visible(false)
}
else
{
	table.column('RecepcionName:name').visible(true)
} if('false' == 'true')
{
	table.column('SexoDescripcion:name').visible(false)
}
else
{
	table.column('SexoDescripcion:name').visible(true)
} if('false' == 'true')
{
	table.column('Edad:name').visible(false)
}
else
{
	table.column('Edad:name').visible(true)
} if('false' == 'true')
{
	table.column('Tipo_de_IdentificacionNombre:name').visible(false)
}
else
{
	table.column('Tipo_de_IdentificacionNombre:name').visible(true)
} if('false' == 'true')
{
	table.column('Numero_de_Identificacion:name').visible(false)
}
else
{
	table.column('Numero_de_Identificacion:name').visible(true)
} if('false' == 'true')
{
	table.column('OrientadorName:name').visible(false)
}
else
{
	table.column('OrientadorName:name').visible(true)
} if('false' == 'true')
{
	table.column('Estatus_de_TurnoDescripcion:name').visible(false)
}
else
{
	table.column('Estatus_de_TurnoDescripcion:name').visible(true)
} if('false' == 'true')
{
	table.column('ModuloDescripcion:name').visible(false)
}
else
{
	table.column('ModuloDescripcion:name').visible(true)
} if('false' == 'true')
{
	table.column('Fecha_de_Asignacion:name').visible(false)
}
else
{
	table.column('Fecha_de_Asignacion:name').visible(true)
} if('false' == 'true')
{
	table.column('Hora_de_Asignacion:name').visible(false)
}
else
{
	table.column('Hora_de_Asignacion:name').visible(true)
} if('false' == 'true')
{
	table.column('Fecha_de_Finalizacion:name').visible(false)
}
else
{
	table.column('Fecha_de_Finalizacion:name').visible(true)
} if('false' == 'true')
{
	table.column('Hora_de_Finalizacion:name').visible(false)
}
else
{
	table.column('Hora_de_Finalizacion:name').visible(true)
}}


}

}