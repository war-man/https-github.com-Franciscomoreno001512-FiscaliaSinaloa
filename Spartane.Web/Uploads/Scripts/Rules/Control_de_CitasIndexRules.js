var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {



debugger;









//BusinessRuleId:2452, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[USERROLEID]'), ReplaceGLOBAL('GLOBAL[USERROLEID]'))==TryParseInt('101', '101') ) { MRWhere=ReplaceQuery("(control_de_citas.reunionmascid is not null and control_de_citas.reunionmascid in (select d.clave from Detalle_de_Reuniones_de_Mediacion d with(nolock) inner join solicitud s with(nolock) on d.numero_de_expediente = s.clave inner join spartan_user u on s.unidad_masc = u.unidad where u.id_user=GLOBAL[USERID]) ) or (control_de_citas.usuario_que_atiende=GLOBAL[USERID])");} else {}

}
//BusinessRuleId:2452, Attribute:3, Operation:Object, Event:None

//BusinessRuleId:2489, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[USERROLEID]'), ReplaceGLOBAL('GLOBAL[USERROLEID]'))==TryParseInt('3', '3') ) { MRWhere=ReplaceQuery("(control_de_citas.reunionmascid is not null and control_de_citas.reunionmascid in (select d.clave from Detalle_de_Reuniones_de_Mediacion d with(nolock) inner join solicitud s with(nolock) on d.numero_de_expediente = s.clave where s.Especialista_AsignadoA=GLOBAL[USERID])) or (control_de_citas.usuario_que_atiende=GLOBAL[USERID])");} else {}

}
//BusinessRuleId:2489, Attribute:3, Operation:Object, Event:None

//BusinessRuleId:2712, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[USERROLEID]'), ReplaceGLOBAL('GLOBAL[USERROLEID]'))==TryParseInt('2', '2') ) { MRWhere=ReplaceQuery("(control_de_citas.reunionmascid is not null "
+" and control_de_citas.reunionmascid in (select d.clave "
+" from Detalle_de_Reuniones_de_Mediacion d with(nolock) "
+" inner join solicitud s with(nolock) on d.numero_de_expediente = s.clave "
+" inner join unidad uni with(nolock) on s.Unidad_MASC = uni.Clave"
+" inner join spartan_user u on uni.Supervisor = u.Id_User"
+" where u.id_user=GLOBAL[USERID]) ) "
+" or (control_de_citas.usuario_que_atiende=GLOBAL[USERID])");} else {}

}
//BusinessRuleId:2712, Attribute:3, Operation:Object, Event:None

//BusinessRuleId:2714, Attribute:3, Operation:Object, Event:None
if(operation == 'List'){
if( TryParseInt(ReplaceGLOBAL('GLOBAL[USERROLEID]'), ReplaceGLOBAL('GLOBAL[USERROLEID]'))==TryParseInt('103', '103') ) { MRWhere=ReplaceQuery("(control_de_citas.ClaveMASC is not null "
+" and control_de_citas.ClaveMASC in (select a.numero_De_expediente "
+" from Acuerdos_MASC a with(nolock) "
+" where a.Personal_de_Seguimiento_Asignado=GLOBAL[USERID])) "
+" or (control_de_citas.usuario_que_atiende=GLOBAL[USERID])");} else {}

}
//BusinessRuleId:2714, Attribute:3, Operation:Object, Event:None

//NEWBUSINESSRULE_BEFORECREATIONLIST//
});

function EjecutarValidacionesDespuesDeCrearLista()
{
//NEWBUSINESSRULE_AFTERCREATIONLIST//
}
