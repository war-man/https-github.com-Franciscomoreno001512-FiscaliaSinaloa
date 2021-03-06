﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_de_Solicitud_Solicitante;
using Spartane.Core.Domain.Adicciones;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Adicciones_de_Solicitante_MASC
{
    /// <summary>
    /// Adicciones_de_Solicitante_MASC table
    /// </summary>
    public class Adicciones_de_Solicitante_MASC: BaseEntity
    {
        public int Clave { get; set; }
        public int? Solicitante { get; set; }
        public int? Descripcion { get; set; }

        [ForeignKey("Solicitante")]
        public virtual Spartane.Core.Domain.Detalle_de_Solicitud_Solicitante.Detalle_de_Solicitud_Solicitante Solicitante_Detalle_de_Solicitud_Solicitante { get; set; }
        [ForeignKey("Descripcion")]
        public virtual Spartane.Core.Domain.Adicciones.Adicciones Descripcion_Adicciones { get; set; }

    }
	
	public class Adicciones_de_Solicitante_MASC_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Solicitante { get; set; }
        public int? Descripcion { get; set; }

		        [ForeignKey("Solicitante")]
        public virtual Spartane.Core.Domain.Detalle_de_Solicitud_Solicitante.Detalle_de_Solicitud_Solicitante Solicitante_Detalle_de_Solicitud_Solicitante { get; set; }
        [ForeignKey("Descripcion")]
        public virtual Spartane.Core.Domain.Adicciones.Adicciones Descripcion_Adicciones { get; set; }

    }


}

