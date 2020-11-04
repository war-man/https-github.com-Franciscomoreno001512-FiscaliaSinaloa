﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Tipo_Delito;
using Spartane.Core.Domain.Grupo_del_Delito;
using Spartane.Core.Domain.Delito;
using Spartane.Core.Domain.Circunstancia_del_Delito;
using Spartane.Core.Domain.Forma_Comision_Delito;
using Spartane.Core.Domain.Forma_Accion_Delito;
using Spartane.Core.Domain.Modalidad_Delito;
using Spartane.Core.Domain.Elementos_Comision_Delito;
using Spartane.Core.Domain.Circunstancia_Vehiculo;
using Spartane.Core.Domain.Especifica_Vehiculo;
using Spartane.Core.Domain.Marca_del_Vehiculo;
using Spartane.Core.Domain.Sub_Marca_del_Vehiculo;
using Spartane.Core.Domain.Tipo_de_Vehiculo;
using Spartane.Core.Domain.Color_Vehiculo;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Aseguradora_de_Vehiculo;
using Spartane.Core.Domain.Servicio_del_Vehiculo;
using Spartane.Core.Domain.Procedencia_del_Vehiculo;
using Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo;
using Spartane.Core.Domain.Circunstancia_Defuncion;
using Spartane.Core.Domain.Consecuencia_Defuncion;
using Spartane.Core.Domain.Lugar_Tipo;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Municipio;
using Spartane.Core.Domain.Zona;
using Spartane.Core.Domain.Colonia;
using Spartane.Core.Domain.Expediente_Inicial;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Detalle_Datos_de_Delito_MPI
{
    /// <summary>
    /// Detalle_Datos_de_Delito_MPI table
    /// </summary>
    public class Detalle_Datos_de_Delito_MPI: BaseEntity
    {
        public int Clave { get; set; }
        public int? Tipo_de_Delito { get; set; }
        public int? Grupo_Delito { get; set; }
        public int? Delito { get; set; }
        public int? Circunstancia_Delito { get; set; }
        public bool? Delito_Principal { get; set; }
        public int? Forma_Comision_Delito { get; set; }
        public short? Forma_Accion_Delito { get; set; }
        public short? Modalidad_Delito { get; set; }
        public int? Elementos_Comision_Delito { get; set; }
        public decimal? Monto { get; set; }
        public bool? Violencia_de_Genero { get; set; }
        public bool? Robo_de_Vehiculo { get; set; }
        public bool? Levantamiento_de_Cadaver { get; set; }
        public short? Circunstancia_de_Vehiculo { get; set; }
        public short? Clase { get; set; }
        public bool? Vehiculo_Robado { get; set; }
        public int? Marca { get; set; }
        public int? Sub_Marca { get; set; }
        public int? Tipo_de_Vehiculo { get; set; }
        public int? Modelo { get; set; }
        public int? Color { get; set; }
        public string Placas { get; set; }
        public int? Estado_de_Origen_de_las_Placas { get; set; }
        public string Motor { get; set; }
        public string Serie { get; set; }
        public bool? El_Vehiculo_esta_Asegurado { get; set; }
        public int? Nombre_de_la_Aseguradora { get; set; }
        public int? Tipo_de_Servicio { get; set; }
        public string Ruta_del_Servicio_Publico { get; set; }
        public short? Procedencia { get; set; }
        public bool? Mercancia { get; set; }
        public string Descripcion_de_lo_que_Transportaba { get; set; }
        public decimal? Monto_de_la_Carga { get; set; }
        public string Senas_Particulares { get; set; }
        public short? Modalidad_del_Robo { get; set; }
        public string Causa_de_Muerte { get; set; }
        public short? Circunstancia_Defuncion { get; set; }
        public short? Consecuencia_Defuncion { get; set; }
        public DateTime? Fecha_Levantamiento { get; set; }
        public string Hora_Levantamiento { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public int? Pais { get; set; }
        public int? Estado { get; set; }
        public int? Municipio { get; set; }
        public int? Zona { get; set; }
        public int? Colonia { get; set; }
        public string Colonia_no_Catalogada { get; set; }
        public int? Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Necropsia { get; set; }
        public string Cronotanatodiagnostico { get; set; }
        public string Ruta { get; set; }
        public bool? Estado_del_Conductor { get; set; }
        public int? Expediente_Inicial_MPI { get; set; }
        public int? Codigo_Postal { get; set; }

        [ForeignKey("Tipo_de_Delito")]
        public virtual Spartane.Core.Domain.Tipo_Delito.Tipo_Delito Tipo_de_Delito_Tipo_Delito { get; set; }
        [ForeignKey("Grupo_Delito")]
        public virtual Spartane.Core.Domain.Grupo_del_Delito.Grupo_del_Delito Grupo_Delito_Grupo_del_Delito { get; set; }
        [ForeignKey("Delito")]
        public virtual Spartane.Core.Domain.Delito.Delito Delito_Delito { get; set; }
        [ForeignKey("Circunstancia_Delito")]
        public virtual Spartane.Core.Domain.Circunstancia_del_Delito.Circunstancia_del_Delito Circunstancia_Delito_Circunstancia_del_Delito { get; set; }
        [ForeignKey("Forma_Comision_Delito")]
        public virtual Spartane.Core.Domain.Forma_Comision_Delito.Forma_Comision_Delito Forma_Comision_Delito_Forma_Comision_Delito { get; set; }
        [ForeignKey("Forma_Accion_Delito")]
        public virtual Spartane.Core.Domain.Forma_Accion_Delito.Forma_Accion_Delito Forma_Accion_Delito_Forma_Accion_Delito { get; set; }
        [ForeignKey("Modalidad_Delito")]
        public virtual Spartane.Core.Domain.Modalidad_Delito.Modalidad_Delito Modalidad_Delito_Modalidad_Delito { get; set; }
        [ForeignKey("Elementos_Comision_Delito")]
        public virtual Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito Elementos_Comision_Delito_Elementos_Comision_Delito { get; set; }
        [ForeignKey("Circunstancia_de_Vehiculo")]
        public virtual Spartane.Core.Domain.Circunstancia_Vehiculo.Circunstancia_Vehiculo Circunstancia_de_Vehiculo_Circunstancia_Vehiculo { get; set; }
        [ForeignKey("Clase")]
        public virtual Spartane.Core.Domain.Especifica_Vehiculo.Especifica_Vehiculo Clase_Especifica_Vehiculo { get; set; }
        [ForeignKey("Marca")]
        public virtual Spartane.Core.Domain.Marca_del_Vehiculo.Marca_del_Vehiculo Marca_Marca_del_Vehiculo { get; set; }
        [ForeignKey("Sub_Marca")]
        public virtual Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo Sub_Marca_Sub_Marca_del_Vehiculo { get; set; }
        [ForeignKey("Tipo_de_Vehiculo")]
        public virtual Spartane.Core.Domain.Tipo_de_Vehiculo.Tipo_de_Vehiculo Tipo_de_Vehiculo_Tipo_de_Vehiculo { get; set; }
        [ForeignKey("Color")]
        public virtual Spartane.Core.Domain.Color_Vehiculo.Color_Vehiculo Color_Color_Vehiculo { get; set; }
        [ForeignKey("Estado_de_Origen_de_las_Placas")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_de_Origen_de_las_Placas_Estado { get; set; }
        [ForeignKey("Nombre_de_la_Aseguradora")]
        public virtual Spartane.Core.Domain.Aseguradora_de_Vehiculo.Aseguradora_de_Vehiculo Nombre_de_la_Aseguradora_Aseguradora_de_Vehiculo { get; set; }
        [ForeignKey("Tipo_de_Servicio")]
        public virtual Spartane.Core.Domain.Servicio_del_Vehiculo.Servicio_del_Vehiculo Tipo_de_Servicio_Servicio_del_Vehiculo { get; set; }
        [ForeignKey("Procedencia")]
        public virtual Spartane.Core.Domain.Procedencia_del_Vehiculo.Procedencia_del_Vehiculo Procedencia_Procedencia_del_Vehiculo { get; set; }
        [ForeignKey("Modalidad_del_Robo")]
        public virtual Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo Modalidad_del_Robo_Modalidad_de_Robo_de_Vehiculo { get; set; }
        [ForeignKey("Circunstancia_Defuncion")]
        public virtual Spartane.Core.Domain.Circunstancia_Defuncion.Circunstancia_Defuncion Circunstancia_Defuncion_Circunstancia_Defuncion { get; set; }
        [ForeignKey("Consecuencia_Defuncion")]
        public virtual Spartane.Core.Domain.Consecuencia_Defuncion.Consecuencia_Defuncion Consecuencia_Defuncion_Consecuencia_Defuncion { get; set; }
        [ForeignKey("Tipo_de_Lugar_del_Hecho")]
        public virtual Spartane.Core.Domain.Lugar_Tipo.Lugar_Tipo Tipo_de_Lugar_del_Hecho_Lugar_Tipo { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Municipio")]
        public virtual Spartane.Core.Domain.Municipio.Municipio Municipio_Municipio { get; set; }
        [ForeignKey("Zona")]
        public virtual Spartane.Core.Domain.Zona.Zona Zona_Zona { get; set; }
        [ForeignKey("Colonia")]
        public virtual Spartane.Core.Domain.Colonia.Colonia Colonia_Colonia { get; set; }
        [ForeignKey("Expediente_Inicial_MPI")]
        public virtual Spartane.Core.Domain.Expediente_Inicial.Expediente_Inicial Expediente_Inicial_MPI_Expediente_Inicial { get; set; }

    }
	
	public class Detalle_Datos_de_Delito_MPI_Datos_Generales
    {
                public int Clave { get; set; }
        public int? Tipo_de_Delito { get; set; }
        public int? Grupo_Delito { get; set; }
        public int? Delito { get; set; }
        public int? Circunstancia_Delito { get; set; }
        public bool? Delito_Principal { get; set; }
        public int? Forma_Comision_Delito { get; set; }
        public short? Forma_Accion_Delito { get; set; }
        public short? Modalidad_Delito { get; set; }
        public int? Elementos_Comision_Delito { get; set; }
        public decimal? Monto { get; set; }
        public bool? Violencia_de_Genero { get; set; }
        public bool? Robo_de_Vehiculo { get; set; }
        public bool? Levantamiento_de_Cadaver { get; set; }
        public int? Expediente_Inicial_MPI { get; set; }

		        [ForeignKey("Tipo_de_Delito")]
        public virtual Spartane.Core.Domain.Tipo_Delito.Tipo_Delito Tipo_de_Delito_Tipo_Delito { get; set; }
        [ForeignKey("Grupo_Delito")]
        public virtual Spartane.Core.Domain.Grupo_del_Delito.Grupo_del_Delito Grupo_Delito_Grupo_del_Delito { get; set; }
        [ForeignKey("Delito")]
        public virtual Spartane.Core.Domain.Delito.Delito Delito_Delito { get; set; }
        [ForeignKey("Circunstancia_Delito")]
        public virtual Spartane.Core.Domain.Circunstancia_del_Delito.Circunstancia_del_Delito Circunstancia_Delito_Circunstancia_del_Delito { get; set; }
        [ForeignKey("Forma_Comision_Delito")]
        public virtual Spartane.Core.Domain.Forma_Comision_Delito.Forma_Comision_Delito Forma_Comision_Delito_Forma_Comision_Delito { get; set; }
        [ForeignKey("Forma_Accion_Delito")]
        public virtual Spartane.Core.Domain.Forma_Accion_Delito.Forma_Accion_Delito Forma_Accion_Delito_Forma_Accion_Delito { get; set; }
        [ForeignKey("Modalidad_Delito")]
        public virtual Spartane.Core.Domain.Modalidad_Delito.Modalidad_Delito Modalidad_Delito_Modalidad_Delito { get; set; }
        [ForeignKey("Elementos_Comision_Delito")]
        public virtual Spartane.Core.Domain.Elementos_Comision_Delito.Elementos_Comision_Delito Elementos_Comision_Delito_Elementos_Comision_Delito { get; set; }
        [ForeignKey("Expediente_Inicial_MPI")]
        public virtual Spartane.Core.Domain.Expediente_Inicial.Expediente_Inicial Expediente_Inicial_MPI_Expediente_Inicial { get; set; }

    }

	public class Detalle_Datos_de_Delito_MPI_Datos_de_Robo_de_Vehiculo
    {
                public int Clave { get; set; }
        public short? Circunstancia_de_Vehiculo { get; set; }
        public short? Clase { get; set; }
        public bool? Vehiculo_Robado { get; set; }
        public int? Marca { get; set; }
        public int? Sub_Marca { get; set; }
        public int? Tipo_de_Vehiculo { get; set; }
        public int? Modelo { get; set; }
        public int? Color { get; set; }
        public string Placas { get; set; }
        public int? Estado_de_Origen_de_las_Placas { get; set; }
        public string Motor { get; set; }
        public string Serie { get; set; }
        public bool? El_Vehiculo_esta_Asegurado { get; set; }
        public int? Nombre_de_la_Aseguradora { get; set; }
        public int? Tipo_de_Servicio { get; set; }
        public string Ruta_del_Servicio_Publico { get; set; }
        public short? Procedencia { get; set; }
        public bool? Mercancia { get; set; }
        public string Descripcion_de_lo_que_Transportaba { get; set; }
        public decimal? Monto_de_la_Carga { get; set; }
        public string Senas_Particulares { get; set; }
        public short? Modalidad_del_Robo { get; set; }

		        [ForeignKey("Circunstancia_de_Vehiculo")]
        public virtual Spartane.Core.Domain.Circunstancia_Vehiculo.Circunstancia_Vehiculo Circunstancia_de_Vehiculo_Circunstancia_Vehiculo { get; set; }
        [ForeignKey("Clase")]
        public virtual Spartane.Core.Domain.Especifica_Vehiculo.Especifica_Vehiculo Clase_Especifica_Vehiculo { get; set; }
        [ForeignKey("Marca")]
        public virtual Spartane.Core.Domain.Marca_del_Vehiculo.Marca_del_Vehiculo Marca_Marca_del_Vehiculo { get; set; }
        [ForeignKey("Sub_Marca")]
        public virtual Spartane.Core.Domain.Sub_Marca_del_Vehiculo.Sub_Marca_del_Vehiculo Sub_Marca_Sub_Marca_del_Vehiculo { get; set; }
        [ForeignKey("Tipo_de_Vehiculo")]
        public virtual Spartane.Core.Domain.Tipo_de_Vehiculo.Tipo_de_Vehiculo Tipo_de_Vehiculo_Tipo_de_Vehiculo { get; set; }
        [ForeignKey("Color")]
        public virtual Spartane.Core.Domain.Color_Vehiculo.Color_Vehiculo Color_Color_Vehiculo { get; set; }
        [ForeignKey("Estado_de_Origen_de_las_Placas")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_de_Origen_de_las_Placas_Estado { get; set; }
        [ForeignKey("Nombre_de_la_Aseguradora")]
        public virtual Spartane.Core.Domain.Aseguradora_de_Vehiculo.Aseguradora_de_Vehiculo Nombre_de_la_Aseguradora_Aseguradora_de_Vehiculo { get; set; }
        [ForeignKey("Tipo_de_Servicio")]
        public virtual Spartane.Core.Domain.Servicio_del_Vehiculo.Servicio_del_Vehiculo Tipo_de_Servicio_Servicio_del_Vehiculo { get; set; }
        [ForeignKey("Procedencia")]
        public virtual Spartane.Core.Domain.Procedencia_del_Vehiculo.Procedencia_del_Vehiculo Procedencia_Procedencia_del_Vehiculo { get; set; }
        [ForeignKey("Modalidad_del_Robo")]
        public virtual Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo Modalidad_del_Robo_Modalidad_de_Robo_de_Vehiculo { get; set; }

    }

	public class Detalle_Datos_de_Delito_MPI_Datos_del_Levantamiento_del_Cadaver_
    {
                public int Clave { get; set; }
        public string Causa_de_Muerte { get; set; }
        public short? Circunstancia_Defuncion { get; set; }
        public short? Consecuencia_Defuncion { get; set; }
        public DateTime? Fecha_Levantamiento { get; set; }
        public string Hora_Levantamiento { get; set; }
        public int? Tipo_de_Lugar_del_Hecho { get; set; }
        public int? Pais { get; set; }
        public int? Estado { get; set; }
        public int? Municipio { get; set; }
        public int? Zona { get; set; }
        public int? Colonia { get; set; }
        public string Colonia_no_Catalogada { get; set; }
        public int? Numero_Exterior { get; set; }
        public string Numero_Interior { get; set; }
        public string Necropsia { get; set; }
        public string Cronotanatodiagnostico { get; set; }
        public string Ruta { get; set; }
        public bool? Estado_del_Conductor { get; set; }
        public int? Codigo_Postal { get; set; }

		        [ForeignKey("Circunstancia_Defuncion")]
        public virtual Spartane.Core.Domain.Circunstancia_Defuncion.Circunstancia_Defuncion Circunstancia_Defuncion_Circunstancia_Defuncion { get; set; }
        [ForeignKey("Consecuencia_Defuncion")]
        public virtual Spartane.Core.Domain.Consecuencia_Defuncion.Consecuencia_Defuncion Consecuencia_Defuncion_Consecuencia_Defuncion { get; set; }
        [ForeignKey("Tipo_de_Lugar_del_Hecho")]
        public virtual Spartane.Core.Domain.Lugar_Tipo.Lugar_Tipo Tipo_de_Lugar_del_Hecho_Lugar_Tipo { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Domain.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Domain.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Municipio")]
        public virtual Spartane.Core.Domain.Municipio.Municipio Municipio_Municipio { get; set; }
        [ForeignKey("Zona")]
        public virtual Spartane.Core.Domain.Zona.Zona Zona_Zona { get; set; }
        [ForeignKey("Colonia")]
        public virtual Spartane.Core.Domain.Colonia.Colonia Colonia_Colonia { get; set; }

    }


}

