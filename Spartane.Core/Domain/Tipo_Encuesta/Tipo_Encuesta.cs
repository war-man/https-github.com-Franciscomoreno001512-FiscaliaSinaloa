﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Modulo_Encuesta;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_Encuesta
{
    /// <summary>
    /// Tipo_Encuesta table
    /// </summary>
    public class Tipo_Encuesta: BaseEntity
    {
        public int Clave { get; set; }
        public int? Modulo_Encuesta { get; set; }
        public string Descripcion { get; set; }
        public string Abreviacion { get; set; }

        [ForeignKey("Modulo_Encuesta")]
        public virtual Spartane.Core.Domain.Modulo_Encuesta.Modulo_Encuesta Modulo_Encuesta_Modulo_Encuesta { get; set; }

    }
	
	public class Tipo_Encuesta_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Modulo_Encuesta { get; set; }
        public string Descripcion { get; set; }
        public string Abreviacion { get; set; }

		        [ForeignKey("Modulo_Encuesta")]
        public virtual Spartane.Core.Domain.Modulo_Encuesta.Modulo_Encuesta Modulo_Encuesta_Modulo_Encuesta { get; set; }

    }


}

