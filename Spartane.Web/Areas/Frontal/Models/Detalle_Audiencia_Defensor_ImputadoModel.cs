﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Audiencia_Defensor_ImputadoModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Nombre_Del_Imputado { get; set; }
        public string Nombre_Del_ImputadoNombre_Completo_del_Tutor { get; set; }
        public string Abogado { get; set; }
        public string Cedula_Profesional { get; set; }

    }
	
	public class Detalle_Audiencia_Defensor_Imputado_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Nombre_Del_Imputado { get; set; }
        public string Nombre_Del_ImputadoNombre_Completo_del_Tutor { get; set; }
        public string Abogado { get; set; }
        public string Cedula_Profesional { get; set; }

    }


}

