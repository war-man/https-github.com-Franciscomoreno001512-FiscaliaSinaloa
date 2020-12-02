﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Tipo_de_Equipo_de_Comunicacion
{
    /// <summary>
    /// Tipo_de_Equipo_de_Comunicacion table
    /// </summary>
    public class Tipo_de_Equipo_de_Comunicacion: BaseEntity
    {
        public short Clave { get; set; }
        public string Descripcion { get; set; }


    }
	
	public class Tipo_de_Equipo_de_Comunicacion_Datos_Generales
    {
                public short Clave { get; set; }
        public string Descripcion { get; set; }

		
    }


}

