﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Consulta_de_Mandamientos_Judiciales;
using Spartane.Core.Domain.Genero;
using Spartane.Core.Domain.Nacionalidad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_de_Resultados
{
    /// <summary>
    /// Detalle_de_Resultados table
    /// </summary>
    public class Detalle_de_Resultados: BaseEntity
    {
        public int Clave { get; set; }
        public int? Consulta_de_Ordenes { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Nacionalidad { get; set; }

        [ForeignKey("Consulta_de_Ordenes")]
        public virtual Spartane.Core.Domain.Consulta_de_Mandamientos_Judiciales.Consulta_de_Mandamientos_Judiciales Consulta_de_Ordenes_Consulta_de_Mandamientos_Judiciales { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Genero.Genero Sexo_Genero { get; set; }
        [ForeignKey("Nacionalidad")]
        public virtual Spartane.Core.Domain.Nacionalidad.Nacionalidad Nacionalidad_Nacionalidad { get; set; }

    }
	
	public class Detalle_de_Resultados_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Consulta_de_Ordenes { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int? Sexo { get; set; }
        public int? Nacionalidad { get; set; }

		        [ForeignKey("Consulta_de_Ordenes")]
        public virtual Spartane.Core.Domain.Consulta_de_Mandamientos_Judiciales.Consulta_de_Mandamientos_Judiciales Consulta_de_Ordenes_Consulta_de_Mandamientos_Judiciales { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Domain.Genero.Genero Sexo_Genero { get; set; }
        [ForeignKey("Nacionalidad")]
        public virtual Spartane.Core.Domain.Nacionalidad.Nacionalidad Nacionalidad_Nacionalidad { get; set; }

    }


}

