﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Aseguramientos;
using Spartane.Core.Domain.Motivo_de_Registro;
using Spartane.Core.Domain.Tipo_de_Pista_de_Aterrizaje;
using Spartane.Core.Domain.Tipo_de_Orientacion;
using Spartane.Core.Domain.Tipo_de_Orientacion;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Aseguramiento_de_Pistas_de_Aterrizaje
{
    /// <summary>
    /// Detalle_Aseguramiento_de_Pistas_de_Aterrizaje table
    /// </summary>
    public class Detalle_Aseguramiento_de_Pistas_de_Aterrizaje: BaseEntity
    {
        public int Clave { get; set; }
        public int? Aseguramiento { get; set; }
        public int? Motivo_de_Registro { get; set; }
        public short? Tipo { get; set; }
        public string Suelo { get; set; }
        public string Descripcion { get; set; }
        public string Localizacion_1 { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Orientacion_de { get; set; }
        public int? Orientacion { get; set; }
        public decimal? Largo { get; set; }
        public decimal? Ancho { get; set; }

        [ForeignKey("Aseguramiento")]
        public virtual Spartane.Core.Domain.Aseguramientos.Aseguramientos Aseguramiento_Aseguramientos { get; set; }
        [ForeignKey("Motivo_de_Registro")]
        public virtual Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro Motivo_de_Registro_Motivo_de_Registro { get; set; }
        [ForeignKey("Tipo")]
        public virtual Spartane.Core.Domain.Tipo_de_Pista_de_Aterrizaje.Tipo_de_Pista_de_Aterrizaje Tipo_Tipo_de_Pista_de_Aterrizaje { get; set; }
        [ForeignKey("Orientacion_de")]
        public virtual Spartane.Core.Domain.Tipo_de_Orientacion.Tipo_de_Orientacion Orientacion_de_Tipo_de_Orientacion { get; set; }
        [ForeignKey("Orientacion")]
        public virtual Spartane.Core.Domain.Tipo_de_Orientacion.Tipo_de_Orientacion Orientacion_Tipo_de_Orientacion { get; set; }

    }
	
	public class Detalle_Aseguramiento_de_Pistas_de_Aterrizaje_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Aseguramiento { get; set; }
        public int? Motivo_de_Registro { get; set; }
        public short? Tipo { get; set; }
        public string Suelo { get; set; }
        public string Descripcion { get; set; }
        public string Localizacion_1 { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Orientacion_de { get; set; }
        public int? Orientacion { get; set; }
        public decimal? Largo { get; set; }
        public decimal? Ancho { get; set; }

		        [ForeignKey("Aseguramiento")]
        public virtual Spartane.Core.Domain.Aseguramientos.Aseguramientos Aseguramiento_Aseguramientos { get; set; }
        [ForeignKey("Motivo_de_Registro")]
        public virtual Spartane.Core.Domain.Motivo_de_Registro.Motivo_de_Registro Motivo_de_Registro_Motivo_de_Registro { get; set; }
        [ForeignKey("Tipo")]
        public virtual Spartane.Core.Domain.Tipo_de_Pista_de_Aterrizaje.Tipo_de_Pista_de_Aterrizaje Tipo_Tipo_de_Pista_de_Aterrizaje { get; set; }
        [ForeignKey("Orientacion_de")]
        public virtual Spartane.Core.Domain.Tipo_de_Orientacion.Tipo_de_Orientacion Orientacion_de_Tipo_de_Orientacion { get; set; }
        [ForeignKey("Orientacion")]
        public virtual Spartane.Core.Domain.Tipo_de_Orientacion.Tipo_de_Orientacion Orientacion_Tipo_de_Orientacion { get; set; }

    }


}

