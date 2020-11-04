﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Bitacora_de_SincronizacionModel
    {
        [Required]
        public int Clave { get; set; }
        public string ID_Dispositivo { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Estatus_de_Replicacion { get; set; }
        public string Estatus_de_ReplicacionDescripcion { get; set; }

    }
	
	public class Bitacora_de_Sincronizacion_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string ID_Dispositivo { get; set; }
        public int? Usuario { get; set; }
        public string UsuarioName { get; set; }
        public string Nombre_de_la_Tabla { get; set; }
        public int? Estatus_de_Replicacion { get; set; }
        public string Estatus_de_ReplicacionDescripcion { get; set; }

    }


}

