﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Vigencia;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Urgencia
{
    /// <summary>
    /// Tipo_de_Urgencia table
    /// </summary>
    public class Tipo_de_Urgencia: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public short? Orden { get; set; }
        public int? Vigente { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Vigente")]
        public virtual Spartane.Core.Domain.Vigencia.Vigencia Vigente_Vigencia { get; set; }

    }
	
	public class Tipo_de_Urgencia_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public short? Orden { get; set; }
        public int? Vigente { get; set; }
        public string Observaciones { get; set; }

		        [ForeignKey("Vigente")]
        public virtual Spartane.Core.Domain.Vigencia.Vigencia Vigente_Vigencia { get; set; }

    }


}

