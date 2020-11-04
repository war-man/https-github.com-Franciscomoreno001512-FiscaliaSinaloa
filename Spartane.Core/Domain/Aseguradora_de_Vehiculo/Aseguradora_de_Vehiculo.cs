﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Aseguradora_de_Vehiculo
{
    /// <summary>
    /// Aseguradora_de_Vehiculo table
    /// </summary>
    public class Aseguradora_de_Vehiculo: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? SNSP { get; set; }


    }
	
	public class Aseguradora_de_Vehiculo_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? SNSP { get; set; }

		
    }


}

