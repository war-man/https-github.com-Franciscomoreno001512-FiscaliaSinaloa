﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_Datos_de_la_Victima_MPIModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Fecha_de_Nacimiento { get; set; }
        [Range(0, 9999999999)]
        public short? Edad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Estado_Civil { get; set; }
        public string Estado_CivilDescripcion { get; set; }
        public int? Tipo_de_Identificacion { get; set; }
        public string Tipo_de_IdentificacionNombre { get; set; }
        public string Numero_de_Identificacion { get; set; }
        public int? Nacionalidad { get; set; }
        public string NacionalidadNacionalidadC { get; set; }
        public short? Escolaridad { get; set; }
        public string EscolaridadDescripcion { get; set; }
        public int? Ocupacion { get; set; }
        public string OcupacionDescripcion { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int? Municipio { get; set; }
        public string MunicipioNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Telefono { get; set; }
        [Range(0, 9999999999)]
        public short? Extencion { get; set; }
        public string Celular { get; set; }
        public string Correo_Electronico { get; set; }
        public bool Incapaz { get; set; }
        public string Nombre_del_Tutor { get; set; }
        public string Apellido_Paterno_del_Tutor { get; set; }
        public string Apellido_Materno_del_Tutor { get; set; }
        public string Nombre_Completo_del_Tutor { get; set; }
        public string Fecha_de_Nacimiento_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_del_Tutor { get; set; }
        public int? Sexo_del_Tutor { get; set; }
        public string Sexo_del_TutorDescripcion { get; set; }
        public int? Estado_Civil_del_Tutor { get; set; }
        public string Estado_Civil_del_TutorDescripcion { get; set; }
        public int? Tipo_de_Identificacion_del_Tutor { get; set; }
        public string Tipo_de_Identificacion_del_TutorNombre { get; set; }
        public string Numero_de_Identificacion_del_Tutor { get; set; }
        public int? Nacionalidad_del_Tutor { get; set; }
        public string Nacionalidad_del_TutorNacionalidadC { get; set; }
        public short? Escolaridad_del_Tutor { get; set; }
        public string Escolaridad_del_TutorDescripcion { get; set; }
        public int? Ocupacion_del_Tutor { get; set; }
        public string Ocupacion_del_TutorDescripcion { get; set; }
        public int? Pais_del_Tutor { get; set; }
        public string Pais_del_TutorNombre { get; set; }
        public int? Estado_del_Tutor { get; set; }
        public string Estado_del_TutorNombre { get; set; }
        public int? Municipio_del_Tutor { get; set; }
        public string Municipio_del_TutorNombre { get; set; }
        public int? Localidad_del_Tutor { get; set; }
        public string Localidad_del_TutorDescripcion { get; set; }
        public int? Colonia_del_Tutor { get; set; }
        public string Colonia_del_TutorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_del_Tutor { get; set; }
        public string Calle_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_Exterior_del_Tutor { get; set; }
        public string Numero_Interior_del_Tutor { get; set; }
        public string Telefono_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public int? Extencion_del_Tutor { get; set; }
        public string Celular_del_Tutor { get; set; }
        public string Correo_Electronico_del_Tutor { get; set; }
        public int? Tipo_de_Compareciente { get; set; }
        public string Tipo_de_ComparecienteDescripcion { get; set; }
        public string Narrativa_de_los_Hechos { get; set; }
        public string Titulo_del_Hecho { get; set; }
        public int? Prioridad_del_Hecho { get; set; }
        public string Prioridad_del_HechoDescripcion { get; set; }
        public string Fecha_del_Hecho { get; set; }
        public string Hora_Aproximada_del_Hecho { get; set; }
        public int? Pais_de_los_Hechos { get; set; }
        public string Pais_de_los_HechosNombre { get; set; }
        public int? Estado_de_los_Hechos { get; set; }
        public string Estado_de_los_HechosNombre { get; set; }
        public int? Municipio_de_los_Hechos { get; set; }
        public string Municipio_de_los_HechosNombre { get; set; }
        public int? Colonia_de_los_Hechos { get; set; }
        public string Colonia_de_los_HechosNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_de_los_Hechos { get; set; }
        public string Calle_de_los_Hechos { get; set; }
        public string Entre_Calle_de_los_Hechos { get; set; }
        public string Y_Calle_de_los_Hechos { get; set; }
        public string Numero_Exterior_de_los_Hechos { get; set; }
        public string Numero_Interior_de_los_Hechos { get; set; }
        public string Latitud_de_los_Hechos { get; set; }
        public string Longitud_de_los_Hechos { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public string Tipo_de_Lugar_del_HechoDescripcion { get; set; }
        public bool Proteccion_de_Datos { get; set; }
        public string Nombre_de_Persona_Moral { get; set; }
        public string Apellido_Paterno_de_Persona_Moral { get; set; }
        public string Apellido_Materno_de_Persona_Moral { get; set; }
        public string Fecha_de_Nacimiento_de_Persona_Moral { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_de_Persona_Moral { get; set; }
        public int? Sexo_de_Persona_Moral { get; set; }
        public string Sexo_de_Persona_MoralDescripcion { get; set; }
        public int? Estado_Civil_de_Persona_Moral { get; set; }
        public string Estado_Civil_de_Persona_MoralDescripcion { get; set; }
        public int? Tipo_de_Identificacion_de_Persona_Moral { get; set; }
        public string Tipo_de_Identificacion_de_Persona_MoralNombre { get; set; }
        public string Numero_de_Identificacion_de_Persona_Mora { get; set; }
        public int? Nacionalidad_de_Persona_Moral { get; set; }
        public string Nacionalidad_de_Persona_MoralNacionalidadC { get; set; }
        public short? Escolaridad_de_Persona_Moral { get; set; }
        public string Escolaridad_de_Persona_MoralDescripcion { get; set; }
        public int? Ocupacion_de_Persona_Moral { get; set; }
        public string Ocupacion_de_Persona_MoralDescripcion { get; set; }
        public int? Pais_de_Persona_Moral { get; set; }
        public string Pais_de_Persona_MoralNombre { get; set; }
        public int? Estado_de_Persona_Moral { get; set; }
        public string Estado_de_Persona_MoralNombre { get; set; }
        public int? Municipio_de_Persona_Moral { get; set; }
        public string Municipio_de_Persona_MoralNombre { get; set; }
        public int? Colonia_de_Persona_Moral { get; set; }
        public string Colonia_de_Persona_MoralNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_de_Persona_Moral { get; set; }
        public string Calle_de_Persona_Moral { get; set; }
        public string Numero_Exterior_de_Persona_Moral { get; set; }
        public string Numero_Interior_de_Persona_Moral { get; set; }
        public string Entre_Calle_de_Persona_Moral { get; set; }
        public string Y_Calle_de_Persona_Moral { get; set; }
        public string Longitud_de_Persona_Moral { get; set; }
        public string Latitud_de_Persona_Moral { get; set; }
        public string Telefono_de_Persona_Moral { get; set; }
        public string Extension_de_Persona_Moral { get; set; }
        public string Celular_de_Persona_Moral { get; set; }
        public string Correo_Electronico_de_Persona_Moral { get; set; }
        public bool Persona_Moral_Victima { get; set; }

    }
	
	public class Detalle_de_Datos_de_la_Victima_MPI_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Fecha_de_Nacimiento { get; set; }
        [Range(0, 9999999999)]
        public short? Edad { get; set; }
        public int? Sexo { get; set; }
        public string SexoDescripcion { get; set; }
        public int? Estado_Civil { get; set; }
        public string Estado_CivilDescripcion { get; set; }
        public int? Tipo_de_Identificacion { get; set; }
        public string Tipo_de_IdentificacionNombre { get; set; }
        public string Numero_de_Identificacion { get; set; }
        public int? Nacionalidad { get; set; }
        public string NacionalidadNacionalidadC { get; set; }
        public short? Escolaridad { get; set; }
        public string EscolaridadDescripcion { get; set; }
        public int? Ocupacion { get; set; }
        public string OcupacionDescripcion { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int? Municipio { get; set; }
        public string MunicipioNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Telefono { get; set; }
        [Range(0, 9999999999)]
        public short? Extencion { get; set; }
        public string Celular { get; set; }
        public string Correo_Electronico { get; set; }
        public bool? Incapaz { get; set; }
        public int? Tipo_de_Compareciente { get; set; }
        public string Tipo_de_ComparecienteDescripcion { get; set; }
        public bool? Proteccion_de_Datos { get; set; }
        public bool? Persona_Moral_Victima { get; set; }

    }

	public class Detalle_de_Datos_de_la_Victima_MPI__Datos_del_TutorModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_del_Tutor { get; set; }
        public string Apellido_Paterno_del_Tutor { get; set; }
        public string Apellido_Materno_del_Tutor { get; set; }
        public string Nombre_Completo_del_Tutor { get; set; }
        public string Fecha_de_Nacimiento_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_del_Tutor { get; set; }
        public int? Sexo_del_Tutor { get; set; }
        public string Sexo_del_TutorDescripcion { get; set; }
        public int? Estado_Civil_del_Tutor { get; set; }
        public string Estado_Civil_del_TutorDescripcion { get; set; }
        public int? Tipo_de_Identificacion_del_Tutor { get; set; }
        public string Tipo_de_Identificacion_del_TutorNombre { get; set; }
        public string Numero_de_Identificacion_del_Tutor { get; set; }
        public int? Nacionalidad_del_Tutor { get; set; }
        public string Nacionalidad_del_TutorNacionalidadC { get; set; }
        public short? Escolaridad_del_Tutor { get; set; }
        public string Escolaridad_del_TutorDescripcion { get; set; }
        public int? Ocupacion_del_Tutor { get; set; }
        public string Ocupacion_del_TutorDescripcion { get; set; }
        public int? Pais_del_Tutor { get; set; }
        public string Pais_del_TutorNombre { get; set; }
        public int? Estado_del_Tutor { get; set; }
        public string Estado_del_TutorNombre { get; set; }
        public int? Municipio_del_Tutor { get; set; }
        public string Municipio_del_TutorNombre { get; set; }
        public int? Localidad_del_Tutor { get; set; }
        public string Localidad_del_TutorDescripcion { get; set; }
        public int? Colonia_del_Tutor { get; set; }
        public string Colonia_del_TutorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_del_Tutor { get; set; }
        public string Calle_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_Exterior_del_Tutor { get; set; }
        public string Numero_Interior_del_Tutor { get; set; }
        public string Telefono_del_Tutor { get; set; }
        [Range(0, 9999999999)]
        public int? Extencion_del_Tutor { get; set; }
        public string Celular_del_Tutor { get; set; }
        public string Correo_Electronico_del_Tutor { get; set; }

    }

	public class Detalle_de_Datos_de_la_Victima_MPI_Datos_de_los_HechosModel
    {
        [Required]
        public int Clave { get; set; }
        public string Narrativa_de_los_Hechos { get; set; }
        public string Titulo_del_Hecho { get; set; }
        public int? Prioridad_del_Hecho { get; set; }
        public string Prioridad_del_HechoDescripcion { get; set; }
        public string Fecha_del_Hecho { get; set; }
        public string Hora_Aproximada_del_Hecho { get; set; }
        public int? Pais_de_los_Hechos { get; set; }
        public string Pais_de_los_HechosNombre { get; set; }
        public int? Estado_de_los_Hechos { get; set; }
        public string Estado_de_los_HechosNombre { get; set; }
        public int? Municipio_de_los_Hechos { get; set; }
        public string Municipio_de_los_HechosNombre { get; set; }
        public int? Colonia_de_los_Hechos { get; set; }
        public string Colonia_de_los_HechosNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_de_los_Hechos { get; set; }
        public string Calle_de_los_Hechos { get; set; }
        public string Entre_Calle_de_los_Hechos { get; set; }
        public string Y_Calle_de_los_Hechos { get; set; }
        public string Numero_Exterior_de_los_Hechos { get; set; }
        public string Numero_Interior_de_los_Hechos { get; set; }
        public string Latitud_de_los_Hechos { get; set; }
        public string Longitud_de_los_Hechos { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public string Tipo_de_Lugar_del_HechoDescripcion { get; set; }

    }

	public class Detalle_de_Datos_de_la_Victima_MPI_Datos_del_AbogadoModel
    {
        [Required]
        public int Clave { get; set; }

    }

	public class Detalle_de_Datos_de_la_Victima_MPI_Datos_de_Persona_MoralModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_de_Persona_Moral { get; set; }
        public string Apellido_Paterno_de_Persona_Moral { get; set; }
        public string Apellido_Materno_de_Persona_Moral { get; set; }
        public string Fecha_de_Nacimiento_de_Persona_Moral { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_de_Persona_Moral { get; set; }
        public int? Sexo_de_Persona_Moral { get; set; }
        public string Sexo_de_Persona_MoralDescripcion { get; set; }
        public int? Estado_Civil_de_Persona_Moral { get; set; }
        public string Estado_Civil_de_Persona_MoralDescripcion { get; set; }
        public int? Tipo_de_Identificacion_de_Persona_Moral { get; set; }
        public string Tipo_de_Identificacion_de_Persona_MoralNombre { get; set; }
        public string Numero_de_Identificacion_de_Persona_Mora { get; set; }
        public int? Nacionalidad_de_Persona_Moral { get; set; }
        public string Nacionalidad_de_Persona_MoralNacionalidadC { get; set; }
        public short? Escolaridad_de_Persona_Moral { get; set; }
        public string Escolaridad_de_Persona_MoralDescripcion { get; set; }
        public int? Ocupacion_de_Persona_Moral { get; set; }
        public string Ocupacion_de_Persona_MoralDescripcion { get; set; }
        public int? Pais_de_Persona_Moral { get; set; }
        public string Pais_de_Persona_MoralNombre { get; set; }
        public int? Estado_de_Persona_Moral { get; set; }
        public string Estado_de_Persona_MoralNombre { get; set; }
        public int? Municipio_de_Persona_Moral { get; set; }
        public string Municipio_de_Persona_MoralNombre { get; set; }
        public int? Colonia_de_Persona_Moral { get; set; }
        public string Colonia_de_Persona_MoralNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_de_Persona_Moral { get; set; }
        public string Calle_de_Persona_Moral { get; set; }
        public string Numero_Exterior_de_Persona_Moral { get; set; }
        public string Numero_Interior_de_Persona_Moral { get; set; }
        public string Entre_Calle_de_Persona_Moral { get; set; }
        public string Y_Calle_de_Persona_Moral { get; set; }
        public string Longitud_de_Persona_Moral { get; set; }
        public string Latitud_de_Persona_Moral { get; set; }
        public string Telefono_de_Persona_Moral { get; set; }
        public string Extension_de_Persona_Moral { get; set; }
        public string Celular_de_Persona_Moral { get; set; }
        public string Correo_Electronico_de_Persona_Moral { get; set; }

    }


}

