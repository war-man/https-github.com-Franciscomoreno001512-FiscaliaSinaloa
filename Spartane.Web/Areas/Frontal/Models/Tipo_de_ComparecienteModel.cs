﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Tipo_de_ComparecienteModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string TP_DescripcionCorta { get; set; }

    }
	
	public class Tipo_de_Compareciente_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public string TP_DescripcionCorta { get; set; }

    }


}

