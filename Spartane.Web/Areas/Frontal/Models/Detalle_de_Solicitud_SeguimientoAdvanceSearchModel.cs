﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_Solicitud_SeguimientoAdvanceSearchModel
    {
        public Detalle_de_Solicitud_SeguimientoAdvanceSearchModel()
        {
            Archivo = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromClave { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromClave", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToClave { set; get; }

        public Filters SolicitudFilter { set; get; }
        public string AdvanceSolicitud { set; get; }
        public int[] AdvanceSolicitudMultiple { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Registro { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Registro", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Registro { set; get; }

        public string ToHora_de_Registro { set; get; }
        public string FromHora_de_Registro { set; get; }

        public Filters RequeridoFilter { set; get; }
        public string AdvanceRequerido { set; get; }
        public int[] AdvanceRequeridoMultiple { set; get; }

        public Filters SolicitanteFilter { set; get; }
        public string AdvanceSolicitante { set; get; }
        public int[] AdvanceSolicitanteMultiple { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_Requerida { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_Requerida", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_Requerida { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromFecha_de_Cumplimiento { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromFecha_de_Cumplimiento", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFecha_de_Cumplimiento { set; get; }

        public Filters CumplimientoFilter { set; get; }
        public string AdvanceCumplimiento { set; get; }
        public int[] AdvanceCumplimientoMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCantidad_del_Monto { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCantidad_del_Monto", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCantidad_del_Monto { set; get; }

        public Filters EspecialistaFilter { set; get; }
        public string AdvanceEspecialista { set; get; }
        public int[] AdvanceEspecialistaMultiple { set; get; }

        public Filters ComentariosFilter { set; get; }
        public string Comentarios { set; get; }

        public RadioOptions Archivo { set; get; }


    }
}
