﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_de_DelitoModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion_corta { get; set; }
        public bool Robo_de_Vehiculo { get; set; }
        public int? Expediente_Inicial { get; set; }
        public string Expediente_InicialNUAT { get; set; }
        public int? Tipo_de_Denuncia { get; set; }
        public string Tipo_de_DenunciaDescripcion { get; set; }
        public string Fecha_del_Delito { get; set; }
        public string Hora_del_Delito { get; set; }
        public bool Violencia_de_Genero { get; set; }
        public int? Delito_Violencia_Genero { get; set; }
        public string Delito_Violencia_GeneroDescripcion { get; set; }
        public int? Tipo_de_Delito { get; set; }
        public string Tipo_de_DelitoDescripcion { get; set; }
        public int? Grupo_Delito { get; set; }
        public string Grupo_DelitoDescripcion { get; set; }
        public int? Delito { get; set; }
        public string DelitoDescripcion { get; set; }
        public int? Circunstancia_Delito { get; set; }
        public string Circunstancia_DelitoDescripcion { get; set; }
        public string Articulado_de_Delito { get; set; }
        public bool Delito_Principal { get; set; }
        public int? Forma_Comision_Delito { get; set; }
        public string Forma_Comision_DelitoDescripcion { get; set; }
        public short? Forma_Accion_Delito { get; set; }
        public string Forma_Accion_DelitoDescripcion { get; set; }
        public short? Modalidad_Delito { get; set; }
        public string Modalidad_DelitoDescripcion { get; set; }
        public int? Elementos_Comision_Delito { get; set; }
        public string Elementos_Comision_DelitoDescripcion { get; set; }
        public int? Clasificacion_con_Orden_de_Resultado { get; set; }
        public string Clasificacion_con_Orden_de_ResultadoDescripcion { get; set; }
        public int? Concurso { get; set; }
        public string ConcursoDescripcion { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Monto { get; set; }
        public int? Estado_del_Delito { get; set; }
        public string Estado_del_DelitoNombre { get; set; }
        public int? Municipio_del_Delito { get; set; }
        public string Municipio_del_DelitoNombre { get; set; }
        public int? Colonia_del_Delito { get; set; }
        public string Colonia_del_DelitoNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public string Calle { get; set; }
        public string Entre_Calle { get; set; }
        public string y_Calle { get; set; }
        public string Numero_Exterior_del_Delito { get; set; }
        public string Numero_Interior_del_Delito { get; set; }
        public string Referencia { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public short? Puede_Ser_Canalizado_a_JA { get; set; }
        public string Puede_Ser_Canalizado_a_JADescripcion { get; set; }
        public int? Motivo_de_no_canalizacion { get; set; }
        public string Motivo_de_no_canalizacionDescripcion { get; set; }
        public bool Se_Informaron_sus_Derechos { get; set; }
        public bool Se_Informo_el_Procedimiento { get; set; }
        public bool Levantamiento_de_Cadaver { get; set; }
        public string Fecha_del_Robo { get; set; }
        public string Hora_del_Robo { get; set; }
        public int? Robo_de { get; set; }
        public string Robo_deDescripcion { get; set; }
        public string Registro_Federal_Vehicular { get; set; }
        public string Numero_de_Registro_Publico_Vehicular { get; set; }
        public short? Circunstancia_de_Vehiculo { get; set; }
        public string Circunstancia_de_VehiculoDescripcion { get; set; }
        public short? Clase { get; set; }
        public string ClaseDescripcion { get; set; }
        public bool Vehiculo_Robado { get; set; }
        public int? Marca { get; set; }
        public string MarcaDescripcion { get; set; }
        public int? Sub_Marca { get; set; }
        public string Sub_MarcaDescripcion { get; set; }
        public int? Tipo_de_Vehiculo { get; set; }
        public string Tipo_de_VehiculoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Modelo { get; set; }
        public int? Color { get; set; }
        public string ColorDescripcion { get; set; }
        public string Placas { get; set; }
        public int? Estado_de_Origen_de_las_Placas { get; set; }
        public string Estado_de_Origen_de_las_PlacasNombre { get; set; }
        public string Numero_de_Motor { get; set; }
        public string Numero_de_Serie { get; set; }
        public int? Estado_del_Robo { get; set; }
        public string Estado_del_RoboNombre { get; set; }
        public int? Municipio_del_Robo { get; set; }
        public string Municipio_del_RoboNombre { get; set; }
        public int? Colonia_del_Robo { get; set; }
        public string Colonia_del_RoboNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_Robo { get; set; }
        public string Calle_Robo { get; set; }
        public string Entre_Calle_Robo { get; set; }
        public string y_Calle_Robo { get; set; }
        public string Numero_Exterior_del_Delito_Robo { get; set; }
        public string Numero_Interior_del_Delito_Robo { get; set; }
        public string Referencia_Robo { get; set; }
        public string Latitud_Robo { get; set; }
        public string Longitud_Robo { get; set; }
        public int? Lugar_del_Robo { get; set; }
        public string Lugar_del_RoboDescripcion { get; set; }
        public bool El_Vehiculo_esta_Asegurado { get; set; }
        public int? Nombre_de_la_Aseguradora { get; set; }
        public string Nombre_de_la_AseguradoraDescripcion { get; set; }
        public string Motor { get; set; }
        public string Serie { get; set; }
        public int? Tipo_de_Servicio { get; set; }
        public string Tipo_de_ServicioDescripcion { get; set; }
        public string Ruta_del_Servicio_Publico { get; set; }
        public short? Procedencia { get; set; }
        public string ProcedenciaDescripcion { get; set; }
        public bool Mercancia { get; set; }
        public string Descripcion_de_lo_que_Transportaba { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Monto_de_la_Carga { get; set; }
        public string Senas_Particulares { get; set; }
        public bool Cuenta_con_GPS { get; set; }
        public int? Tipo_de_Robo { get; set; }
        public string Tipo_de_RoboDescripcion { get; set; }
        public int? Tipo_de_Lugar_del_Robo { get; set; }
        public string Tipo_de_Lugar_del_RoboDescripcion { get; set; }
        public int? Tipo_de_Carretera { get; set; }
        public string Tipo_de_CarreteraDescripcion { get; set; }
        public short? Modalidad_del_Robo { get; set; }
        public string Modalidad_del_RoboDescripcion { get; set; }
        public string Causa_de_Muerte { get; set; }
        public short? Circunstancia_Defuncion { get; set; }
        public string Circunstancia_DefuncionDescripcion { get; set; }
        public short? Consecuencia_Defuncion { get; set; }
        public string Consecuencia_DefuncionDescripcion { get; set; }
        public string Fecha_Levantamiento { get; set; }
        public string Hora_Levantamiento { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public string Tipo_de_Lugar_del_HechoDescripcion { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int? Municipio { get; set; }
        public string MunicipioNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        public string Colonia_no_Catalogada { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Necropsia { get; set; }
        public string Cronotanatodiagnostico { get; set; }
        public string Ruta { get; set; }
        public bool Estado_del_Conductor { get; set; }
        public bool Persona_Moral_Dueno { get; set; }
        public int? Nombre_Completo { get; set; }
        public string Nombre_CompletoNombre { get; set; }
        public bool Persona_Fisica_Dueno { get; set; }
        public int? Nombre_Completo_Involucrado { get; set; }
        public string Nombre_Completo_InvolucradoNombre_del_Tutor { get; set; }
        public bool Denunciante_dueno { get; set; }
        public int? Nombre_Completo_Dueno { get; set; }
        public string Nombre_Completo_DuenoNombre_del_Tutor { get; set; }

    }
	
	public class Detalle_de_Delito_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Descripcion_corta { get; set; }
        public bool? Robo_de_Vehiculo { get; set; }
        public int? Expediente_Inicial { get; set; }
        public string Expediente_InicialNUAT { get; set; }
        public int? Tipo_de_Denuncia { get; set; }
        public string Tipo_de_DenunciaDescripcion { get; set; }
        public string Fecha_del_Delito { get; set; }
        public string Hora_del_Delito { get; set; }
        public bool? Violencia_de_Genero { get; set; }
        public int? Delito_Violencia_Genero { get; set; }
        public string Delito_Violencia_GeneroDescripcion { get; set; }
        public int? Tipo_de_Delito { get; set; }
        public string Tipo_de_DelitoDescripcion { get; set; }
        public int? Grupo_Delito { get; set; }
        public string Grupo_DelitoDescripcion { get; set; }
        public int? Delito { get; set; }
        public string DelitoDescripcion { get; set; }
        public int? Circunstancia_Delito { get; set; }
        public string Circunstancia_DelitoDescripcion { get; set; }
        public string Articulado_de_Delito { get; set; }
        public bool? Delito_Principal { get; set; }
        public int? Forma_Comision_Delito { get; set; }
        public string Forma_Comision_DelitoDescripcion { get; set; }
        public short? Forma_Accion_Delito { get; set; }
        public string Forma_Accion_DelitoDescripcion { get; set; }
        public short? Modalidad_Delito { get; set; }
        public string Modalidad_DelitoDescripcion { get; set; }
        public int? Elementos_Comision_Delito { get; set; }
        public string Elementos_Comision_DelitoDescripcion { get; set; }
        public int? Clasificacion_con_Orden_de_Resultado { get; set; }
        public string Clasificacion_con_Orden_de_ResultadoDescripcion { get; set; }
        public int? Concurso { get; set; }
        public string ConcursoDescripcion { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Monto { get; set; }
        public int? Estado_del_Delito { get; set; }
        public string Estado_del_DelitoNombre { get; set; }
        public int? Municipio_del_Delito { get; set; }
        public string Municipio_del_DelitoNombre { get; set; }
        public int? Colonia_del_Delito { get; set; }
        public string Colonia_del_DelitoNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal { get; set; }
        public string Calle { get; set; }
        public string Entre_Calle { get; set; }
        public string y_Calle { get; set; }
        public string Numero_Exterior_del_Delito { get; set; }
        public string Numero_Interior_del_Delito { get; set; }
        public string Referencia { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public short? Puede_Ser_Canalizado_a_JA { get; set; }
        public string Puede_Ser_Canalizado_a_JADescripcion { get; set; }
        public int? Motivo_de_no_canalizacion { get; set; }
        public string Motivo_de_no_canalizacionDescripcion { get; set; }
        public bool? Se_Informaron_sus_Derechos { get; set; }
        public bool? Se_Informo_el_Procedimiento { get; set; }
        public bool? Levantamiento_de_Cadaver { get; set; }

    }

	public class Detalle_de_Delito_Datos_de_Robo_de_VehiculoModel
    {
        [Required]
        public int Clave { get; set; }
        public string Fecha_del_Robo { get; set; }
        public string Hora_del_Robo { get; set; }
        public int? Robo_de { get; set; }
        public string Robo_deDescripcion { get; set; }
        public string Registro_Federal_Vehicular { get; set; }
        public string Numero_de_Registro_Publico_Vehicular { get; set; }
        public short? Circunstancia_de_Vehiculo { get; set; }
        public string Circunstancia_de_VehiculoDescripcion { get; set; }
        public short? Clase { get; set; }
        public string ClaseDescripcion { get; set; }
        public bool? Vehiculo_Robado { get; set; }
        public int? Marca { get; set; }
        public string MarcaDescripcion { get; set; }
        public int? Sub_Marca { get; set; }
        public string Sub_MarcaDescripcion { get; set; }
        public int? Tipo_de_Vehiculo { get; set; }
        public string Tipo_de_VehiculoDescripcion { get; set; }
        [Range(0, 9999999999)]
        public int? Modelo { get; set; }
        public int? Color { get; set; }
        public string ColorDescripcion { get; set; }
        public string Placas { get; set; }
        public int? Estado_de_Origen_de_las_Placas { get; set; }
        public string Estado_de_Origen_de_las_PlacasNombre { get; set; }
        public string Numero_de_Motor { get; set; }
        public string Numero_de_Serie { get; set; }
        public int? Estado_del_Robo { get; set; }
        public string Estado_del_RoboNombre { get; set; }
        public int? Municipio_del_Robo { get; set; }
        public string Municipio_del_RoboNombre { get; set; }
        public int? Colonia_del_Robo { get; set; }
        public string Colonia_del_RoboNombre { get; set; }
        [Range(0, 9999999999)]
        public int? Codigo_Postal_Robo { get; set; }
        public string Calle_Robo { get; set; }
        public string Entre_Calle_Robo { get; set; }
        public string y_Calle_Robo { get; set; }
        public string Numero_Exterior_del_Delito_Robo { get; set; }
        public string Numero_Interior_del_Delito_Robo { get; set; }
        public string Referencia_Robo { get; set; }
        public string Latitud_Robo { get; set; }
        public string Longitud_Robo { get; set; }
        public int? Lugar_del_Robo { get; set; }
        public string Lugar_del_RoboDescripcion { get; set; }
        public bool? El_Vehiculo_esta_Asegurado { get; set; }
        public int? Nombre_de_la_Aseguradora { get; set; }
        public string Nombre_de_la_AseguradoraDescripcion { get; set; }
        public string Motor { get; set; }
        public string Serie { get; set; }
        public int? Tipo_de_Servicio { get; set; }
        public string Tipo_de_ServicioDescripcion { get; set; }
        public string Ruta_del_Servicio_Publico { get; set; }
        public short? Procedencia { get; set; }
        public string ProcedenciaDescripcion { get; set; }
        public bool? Mercancia { get; set; }
        public string Descripcion_de_lo_que_Transportaba { get; set; }
        [Range(0.00, 999999.99)]
        public decimal? Monto_de_la_Carga { get; set; }
        public string Senas_Particulares { get; set; }
        public bool? Cuenta_con_GPS { get; set; }
        public int? Tipo_de_Robo { get; set; }
        public string Tipo_de_RoboDescripcion { get; set; }
        public int? Tipo_de_Lugar_del_Robo { get; set; }
        public string Tipo_de_Lugar_del_RoboDescripcion { get; set; }
        public int? Tipo_de_Carretera { get; set; }
        public string Tipo_de_CarreteraDescripcion { get; set; }
        public short? Modalidad_del_Robo { get; set; }
        public string Modalidad_del_RoboDescripcion { get; set; }

    }

	public class Detalle_de_Delito_Datos_del_Levantamiento_del_CadaverModel
    {
        [Required]
        public int Clave { get; set; }
        public string Causa_de_Muerte { get; set; }
        public short? Circunstancia_Defuncion { get; set; }
        public string Circunstancia_DefuncionDescripcion { get; set; }
        public short? Consecuencia_Defuncion { get; set; }
        public string Consecuencia_DefuncionDescripcion { get; set; }
        public string Fecha_Levantamiento { get; set; }
        public string Hora_Levantamiento { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public string Tipo_de_Lugar_del_HechoDescripcion { get; set; }
        public int? Pais { get; set; }
        public string PaisNombre { get; set; }
        public int? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int? Municipio { get; set; }
        public string MunicipioNombre { get; set; }
        public int? Colonia { get; set; }
        public string ColoniaNombre { get; set; }
        public string Colonia_no_Catalogada { get; set; }
        [Range(0, 9999999999)]
        public int? Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Necropsia { get; set; }
        public string Cronotanatodiagnostico { get; set; }
        public string Ruta { get; set; }
        public bool? Estado_del_Conductor { get; set; }

    }

	public class Detalle_de_Delito_Asignar_DuenoModel
    {
        [Required]
        public int Clave { get; set; }
        public bool? Persona_Moral_Dueno { get; set; }
        public int? Nombre_Completo { get; set; }
        public string Nombre_CompletoNombre { get; set; }
        public bool? Persona_Fisica_Dueno { get; set; }
        public int? Nombre_Completo_Involucrado { get; set; }
        public string Nombre_Completo_InvolucradoNombre_del_Tutor { get; set; }
        public bool? Denunciante_dueno { get; set; }
        public int? Nombre_Completo_Dueno { get; set; }
        public string Nombre_Completo_DuenoNombre_del_Tutor { get; set; }

    }


}

