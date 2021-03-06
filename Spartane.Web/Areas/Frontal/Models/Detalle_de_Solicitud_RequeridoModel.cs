﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_Solicitud_RequeridoModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? idRegistroAT { get; set; }
        [Range(0, 9999999999)]
        public int? idRegistroUI { get; set; }
        public int? Solicitud { get; set; }
        public string SolicitudNumero_de_Folio { get; set; }
        public bool A_Quien_Sea_Responsable { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Alias { get; set; }
        public string Apodo { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
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
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public int? Poblacion { get; set; }
        public string PoblacionNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Entre_Calle { get; set; }
        public string Y_Calle { get; set; }
        public string Referencia_de_Domicilio_Requerido { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        public string Extencion { get; set; }
        public string Celular { get; set; }
        public string Correo_Electronico { get; set; }
        public int? Pais_de_Origen { get; set; }
        public string Pais_de_OrigenNombre { get; set; }
        public string Originario_de { get; set; }
        public int? Estado_de_Nacimiento { get; set; }
        public string Estado_de_NacimientoNombre { get; set; }
        public int? Municipio_de_Nacimiento { get; set; }
        public string Municipio_de_NacimientoNombre { get; set; }
        public bool Inimputable { get; set; }
        public int? Tipo_de_Inimputabilidad { get; set; }
        public string Tipo_de_InimputabilidadDescripcion { get; set; }
        public bool Se_Presenta_con_Detenido { get; set; }
        public string Folio_Registro_Nacional_de_Detenciones { get; set; }
        public string Fecha_de_Detencion { get; set; }
        public int? Municipio_de_Detencion { get; set; }
        public string Municipio_de_DetencionNombre { get; set; }
        public int? Corporacion { get; set; }
        public string CorporacionDescripcion { get; set; }
        public bool Suspension_Condicional { get; set; }
        public string Fecha_de_Suspension_Condicional { get; set; }
        public string Lugar_donde_se_Encuentra_Detenido { get; set; }
        public int? Etnia { get; set; }
        public string EtniaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public short? No__de_Hijos { get; set; }
        public short? Religion { get; set; }
        public string ReligionDescripcion { get; set; }
        public int? Servicio_Medico { get; set; }
        public string Servicio_MedicoDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public int? Estudios_Superiores { get; set; }
        public string Estudios_SuperioresDescripcion { get; set; }
        public int? Idioma { get; set; }
        public string IdiomaDescripcion { get; set; }
        public int? Calidad_Migratoria { get; set; }
        public string Calidad_MigratoriaDescripcion { get; set; }
        public int? Dialecto { get; set; }
        public string DialectoDescripcion { get; set; }
        public bool Viene_en_Estado_de_Ebriedad { get; set; }
        public bool Bajo_el_Efecto_de_una_Droga { get; set; }
        public string Nombre_de_Droga { get; set; }
        public int? Discapacidad_Mental { get; set; }
        public string Discapacidad_MentalDescripcion { get; set; }
        public int? Discapacidad_Fisica { get; set; }
        public string Discapacidad_FisicaDescripcion { get; set; }
        public int? Discapacidad_Sensorial { get; set; }
        public string Discapacidad_SensorialDescripcion { get; set; }
        public int? Discapacidad_Psicosocial { get; set; }
        public string Discapacidad_PsicosocialDescripcion { get; set; }
        public string Nombre_de_Tutor { get; set; }
        public string Apellido_Paterno_Tutor { get; set; }
        public string Apellido_Materno_Tutor { get; set; }
        public string Nombre_Completo_Tutor { get; set; }
        public string Fecha_de_Nacimiento_tutor { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_tutor { get; set; }
        public int? Sexo_tutor { get; set; }
        public string Sexo_tutorDescripcion { get; set; }
        public int? Estado_Civil_tutor { get; set; }
        public string Estado_Civil_tutorDescripcion { get; set; }
        public int? Tipo_de_Identificacion_tutor { get; set; }
        public string Tipo_de_Identificacion_tutorNombre { get; set; }
        public string Numero_de_Identificacion_tutor { get; set; }
        public int? Nacionalidad_tutor { get; set; }
        public string Nacionalidad_tutorNacionalidadC { get; set; }
        public short? Escolaridad_tutor { get; set; }
        public string Escolaridad_tutorDescripcion { get; set; }
        public int? Ocupacion_tutor { get; set; }
        public string Ocupacion_tutorDescripcion { get; set; }
        public int? Pais_tutor { get; set; }
        public string Pais_tutorNombre { get; set; }
        public int? Estado_tutor { get; set; }
        public string Estado_tutorNombre { get; set; }
        public int? Municipio_tutor { get; set; }
        public string Municipio_tutorNombre { get; set; }
        public int? Poblacion_tutor { get; set; }
        public string Poblacion_tutorNombre { get; set; }
        public int? Colonia_tutor { get; set; }
        public string Colonia_tutorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_tutor { get; set; }
        public string Calle_tutor { get; set; }
        public string Numero_Exterior_tutor { get; set; }
        public string Numero_Interior_tutor { get; set; }
        public string Referencia { get; set; }
        public string Latitud_tutor { get; set; }
        public string Longitud_tutor { get; set; }
        public string Extension_tutor { get; set; }
        public string Celular_tutor { get; set; }
        public string Correo_Electronico_tutor { get; set; }
        public int? Pais_de_Origen_Tutor { get; set; }
        public string Pais_de_Origen_TutorNombre { get; set; }
        public string Originario_de_Tutor { get; set; }
        public string CURP_Tutor { get; set; }
        public string RFC_Tutor { get; set; }
        public string Padecimiento_de_Enfermedad { get; set; }
        public int? Cejas { get; set; }
        public string CejasDescripcion { get; set; }
        public int? Tamano_de_Cejas { get; set; }
        public string Tamano_de_CejasDescripcion { get; set; }
        public int? Anteojos { get; set; }
        public string AnteojosDescripcion { get; set; }
        public int? Forma_de_Nariz { get; set; }
        public string Forma_de_NarizDescripcion { get; set; }
        public int? Nariz_base { get; set; }
        public string Nariz_baseDescripcion { get; set; }
        public int? Grosor_de_Labios { get; set; }
        public string Grosor_de_LabiosDescripcion { get; set; }
        public int? Forma_de_Menton { get; set; }
        public string Forma_de_MentonDescripcion { get; set; }
        public int? Senas_Particulares { get; set; }
        public string Senas_ParticularesDescripcion { get; set; }
        public int? Imagen_Tatuaje { get; set; }
        public HttpPostedFileBase Imagen_TatuajeFile { set; get; }
        public int Imagen_TatuajeRemoveAttachment { set; get; }
        public string Otras_Senas_Particulares { get; set; }
        public string Imputado_Recluido { get; set; }

    }
	
	public class Detalle_de_Solicitud_Requerido_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        [Range(0, 9999999999)]
        public int? idRegistroAT { get; set; }
        [Range(0, 9999999999)]
        public int? idRegistroUI { get; set; }
        public int? Solicitud { get; set; }
        public string SolicitudNumero_de_Folio { get; set; }
        public bool? A_Quien_Sea_Responsable { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Alias { get; set; }
        public string Apodo { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
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
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public int? Poblacion { get; set; }
        public string PoblacionNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        public string Calle { get; set; }
        public string Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Entre_Calle { get; set; }
        public string Y_Calle { get; set; }
        public string Referencia_de_Domicilio_Requerido { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Telefono { get; set; }
        public string Extencion { get; set; }
        public string Celular { get; set; }
        public string Correo_Electronico { get; set; }
        public int? Pais_de_Origen { get; set; }
        public string Pais_de_OrigenNombre { get; set; }
        public string Originario_de { get; set; }
        public int? Estado_de_Nacimiento { get; set; }
        public string Estado_de_NacimientoNombre { get; set; }
        public int? Municipio_de_Nacimiento { get; set; }
        public string Municipio_de_NacimientoNombre { get; set; }
        public bool? Inimputable { get; set; }
        public int? Tipo_de_Inimputabilidad { get; set; }
        public string Tipo_de_InimputabilidadDescripcion { get; set; }
        public bool? Se_Presenta_con_Detenido { get; set; }
        public string Folio_Registro_Nacional_de_Detenciones { get; set; }
        public string Fecha_de_Detencion { get; set; }
        public int? Municipio_de_Detencion { get; set; }
        public string Municipio_de_DetencionNombre { get; set; }
        public int? Corporacion { get; set; }
        public string CorporacionDescripcion { get; set; }
        public bool? Suspension_Condicional { get; set; }
        public string Fecha_de_Suspension_Condicional { get; set; }
        public string Lugar_donde_se_Encuentra_Detenido { get; set; }
        public int? Etnia { get; set; }
        public string EtniaDescripcion { get; set; }
        [Range(0, 9999999999)]
        public short? No__de_Hijos { get; set; }
        public short? Religion { get; set; }
        public string ReligionDescripcion { get; set; }
        public int? Servicio_Medico { get; set; }
        public string Servicio_MedicoDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public int? Estudios_Superiores { get; set; }
        public string Estudios_SuperioresDescripcion { get; set; }
        public int? Idioma { get; set; }
        public string IdiomaDescripcion { get; set; }
        public int? Calidad_Migratoria { get; set; }
        public string Calidad_MigratoriaDescripcion { get; set; }
        public int? Dialecto { get; set; }
        public string DialectoDescripcion { get; set; }
        public bool? Viene_en_Estado_de_Ebriedad { get; set; }
        public bool? Bajo_el_Efecto_de_una_Droga { get; set; }
        public string Nombre_de_Droga { get; set; }
        public int? Discapacidad_Mental { get; set; }
        public string Discapacidad_MentalDescripcion { get; set; }
        public int? Discapacidad_Fisica { get; set; }
        public string Discapacidad_FisicaDescripcion { get; set; }
        public int? Discapacidad_Sensorial { get; set; }
        public string Discapacidad_SensorialDescripcion { get; set; }
        public int? Discapacidad_Psicosocial { get; set; }
        public string Discapacidad_PsicosocialDescripcion { get; set; }

    }

	public class Detalle_de_Solicitud_Requerido_Datos_del_TutorModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_de_Tutor { get; set; }
        public string Apellido_Paterno_Tutor { get; set; }
        public string Apellido_Materno_Tutor { get; set; }
        public string Nombre_Completo_Tutor { get; set; }
        public string Fecha_de_Nacimiento_tutor { get; set; }
        [Range(0, 9999999999)]
        public short? Edad_tutor { get; set; }
        public int? Sexo_tutor { get; set; }
        public string Sexo_tutorDescripcion { get; set; }
        public int? Estado_Civil_tutor { get; set; }
        public string Estado_Civil_tutorDescripcion { get; set; }
        public int? Tipo_de_Identificacion_tutor { get; set; }
        public string Tipo_de_Identificacion_tutorNombre { get; set; }
        public string Numero_de_Identificacion_tutor { get; set; }
        public int? Nacionalidad_tutor { get; set; }
        public string Nacionalidad_tutorNacionalidadC { get; set; }
        public short? Escolaridad_tutor { get; set; }
        public string Escolaridad_tutorDescripcion { get; set; }
        public int? Ocupacion_tutor { get; set; }
        public string Ocupacion_tutorDescripcion { get; set; }
        public int? Pais_tutor { get; set; }
        public string Pais_tutorNombre { get; set; }
        public int? Estado_tutor { get; set; }
        public string Estado_tutorNombre { get; set; }
        public int? Municipio_tutor { get; set; }
        public string Municipio_tutorNombre { get; set; }
        public int? Poblacion_tutor { get; set; }
        public string Poblacion_tutorNombre { get; set; }
        public int? Colonia_tutor { get; set; }
        public string Colonia_tutorNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_tutor { get; set; }
        public string Calle_tutor { get; set; }
        public string Numero_Exterior_tutor { get; set; }
        public string Numero_Interior_tutor { get; set; }
        public string Referencia { get; set; }
        public string Latitud_tutor { get; set; }
        public string Longitud_tutor { get; set; }
        public string Extension_tutor { get; set; }
        public string Celular_tutor { get; set; }
        public string Correo_Electronico_tutor { get; set; }
        public int? Pais_de_Origen_Tutor { get; set; }
        public string Pais_de_Origen_TutorNombre { get; set; }
        public string Originario_de_Tutor { get; set; }
        public string CURP_Tutor { get; set; }
        public string RFC_Tutor { get; set; }

    }

	public class Detalle_de_Solicitud_Requerido_Datos_de_Media_FiliacionModel
    {
        [Required]
        public int Clave { get; set; }
        public string Padecimiento_de_Enfermedad { get; set; }
        public int? Cejas { get; set; }
        public string CejasDescripcion { get; set; }
        public int? Tamano_de_Cejas { get; set; }
        public string Tamano_de_CejasDescripcion { get; set; }
        public int? Anteojos { get; set; }
        public string AnteojosDescripcion { get; set; }
        public int? Forma_de_Nariz { get; set; }
        public string Forma_de_NarizDescripcion { get; set; }
        public int? Nariz_base { get; set; }
        public string Nariz_baseDescripcion { get; set; }
        public int? Grosor_de_Labios { get; set; }
        public string Grosor_de_LabiosDescripcion { get; set; }
        public int? Forma_de_Menton { get; set; }
        public string Forma_de_MentonDescripcion { get; set; }
        public int? Senas_Particulares { get; set; }
        public string Senas_ParticularesDescripcion { get; set; }
        public int? Imagen_Tatuaje { get; set; }
        public HttpPostedFileBase Imagen_TatuajeFile { set; get; }
        public int Imagen_TatuajeRemoveAttachment { set; get; }
        public string Otras_Senas_Particulares { get; set; }
        public string Imputado_Recluido { get; set; }

    }


}

