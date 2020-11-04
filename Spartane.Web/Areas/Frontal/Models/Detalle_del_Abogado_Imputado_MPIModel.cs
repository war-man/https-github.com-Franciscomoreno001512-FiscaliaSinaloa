﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_del_Abogado_Imputado_MPIModel
    {
        [Required]
        public int Consecutivo { get; set; }
        public int? Nombre_Completo_del_Abogado { get; set; }
        public string Nombre_Completo_del_AbogadoNombre_Completo { get; set; }
        public string Nombre_del_Abogado { get; set; }
        public string Apellido_Paterno_del_Abogado { get; set; }
        public string Apellido_Materno_del_Abogado { get; set; }
        public string Fecha_de_Nacimiento_del_Abogado { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_del_Abogado { get; set; }
        public int? Sexo_del_Abogado { get; set; }
        public string Sexo_del_AbogadoDescripcion { get; set; }
        public int? Estado_Civil_del_Abogado { get; set; }
        public string Estado_Civil_del_AbogadoDescripcion { get; set; }
        public int? Tipo_de_Identificacion_del_Abogado { get; set; }
        public string Tipo_de_Identificacion_del_AbogadoNombre { get; set; }
        public string Numero_de_Identificacion_del_Abogado { get; set; }
        public int? Nacionalidad_del_Abogado { get; set; }
        public string Nacionalidad_del_AbogadoNacionalidadC { get; set; }
        public string Cedula_Profesional_del_Abogado { get; set; }
        public int? Pais_del_Abogado { get; set; }
        public string Pais_del_AbogadoNombre { get; set; }
        public int? Estado_del_Abogado { get; set; }
        public string Estado_del_AbogadoNombre { get; set; }
        public int? Municipio_del_Abogado { get; set; }
        public string Municipio_del_AbogadoNombre { get; set; }
        public int? Colonia_del_Abogado { get; set; }
        public string Colonia_del_AbogadoNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_del_Abogado { get; set; }
        public string Calle_del_Abogado { get; set; }
        public string Numero_Exterior_del_Abogado { get; set; }
        public string Numero_Interior_del_Abogado { get; set; }
        public string Telefono_del_Abogado { get; set; }
        public string Celular_del_Abogado { get; set; }
        public string Correo_Electronico_del_Abogado { get; set; }
        public bool Aceptar_Notificaciones { get; set; }

    }
	
	public class Detalle_del_Abogado_Imputado_MPI_Datos_GeneralesModel
    {
        [Required]
        public int Consecutivo { get; set; }
        public int? Nombre_Completo_del_Abogado { get; set; }
        public string Nombre_Completo_del_AbogadoNombre_Completo { get; set; }
        public string Nombre_del_Abogado { get; set; }
        public string Apellido_Paterno_del_Abogado { get; set; }
        public string Apellido_Materno_del_Abogado { get; set; }
        public string Fecha_de_Nacimiento_del_Abogado { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_del_Abogado { get; set; }
        public int? Sexo_del_Abogado { get; set; }
        public string Sexo_del_AbogadoDescripcion { get; set; }
        public int? Estado_Civil_del_Abogado { get; set; }
        public string Estado_Civil_del_AbogadoDescripcion { get; set; }
        public int? Tipo_de_Identificacion_del_Abogado { get; set; }
        public string Tipo_de_Identificacion_del_AbogadoNombre { get; set; }
        public string Numero_de_Identificacion_del_Abogado { get; set; }
        public int? Nacionalidad_del_Abogado { get; set; }
        public string Nacionalidad_del_AbogadoNacionalidadC { get; set; }
        public string Cedula_Profesional_del_Abogado { get; set; }
        public int? Pais_del_Abogado { get; set; }
        public string Pais_del_AbogadoNombre { get; set; }
        public int? Estado_del_Abogado { get; set; }
        public string Estado_del_AbogadoNombre { get; set; }
        public int? Municipio_del_Abogado { get; set; }
        public string Municipio_del_AbogadoNombre { get; set; }
        public int? Colonia_del_Abogado { get; set; }
        public string Colonia_del_AbogadoNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_del_Abogado { get; set; }
        public string Calle_del_Abogado { get; set; }
        public string Numero_Exterior_del_Abogado { get; set; }
        public string Numero_Interior_del_Abogado { get; set; }
        public string Telefono_del_Abogado { get; set; }
        public string Celular_del_Abogado { get; set; }
        public string Correo_Electronico_del_Abogado { get; set; }
        public bool? Aceptar_Notificaciones { get; set; }

    }


}

