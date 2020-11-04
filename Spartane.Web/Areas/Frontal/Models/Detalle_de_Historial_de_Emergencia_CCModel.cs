﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_Historial_de_Emergencia_CCModel
    {
        [Required]
        public int Clave { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Estatus { get; set; }
        public string Comentarios { get; set; }
        public string Usuario_que_registra { get; set; }

    }
	
	public class Detalle_de_Historial_de_Emergencia_CC_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Estatus { get; set; }
        public string Comentarios { get; set; }
        public string Usuario_que_registra { get; set; }

    }


}

