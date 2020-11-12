﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Solicitud_Historial_de_AsignacionesGridModel
    {
        public int Folio { get; set; }
        public string Fecha_cambio { get; set; }
        public string Hora_cambio { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public int? Facilitador_Asignado { get; set; }
        public string Facilitador_AsignadoName { get; set; }
        public string Motivo_de_cambio { get; set; }
        
    }
}

