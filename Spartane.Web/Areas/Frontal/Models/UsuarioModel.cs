﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class UsuarioModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Nombre { get; set; }
        public string NombreName { get; set; }
        public string Clave_de_Acceso { get; set; }
        [Range(0, 9999999999)]
        public short? Grupo_de_Usuario { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Correo_Institucional { get; set; }
        public string CUIP { get; set; }
        public int? Delegacion { get; set; }
        public string DelegacionDescripcion { get; set; }
        [Range(0, 9999999999)]
        public short? Carga_de_Trabajo { get; set; }
        public string Nombre_Remitente { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public int? Agencia { get; set; }
        public string AgenciaDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public string ID_de_Dispositivo { get; set; }
        public string ID_de_Huella { get; set; }
        [Range(0, 9999999999)]
        public short? Fotografia { get; set; }
        [Range(0, 9999999999)]
        public int? Usuario_que_Registra { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Estatus_de_Registro { get; set; }

    }
	
	public class Usuario_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Nombre { get; set; }
        public string NombreName { get; set; }
        public string Clave_de_Acceso { get; set; }
        [Range(0, 9999999999)]
        public short? Grupo_de_Usuario { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Correo_Institucional { get; set; }
        public string CUIP { get; set; }
        public int? Delegacion { get; set; }
        public string DelegacionDescripcion { get; set; }
        [Range(0, 9999999999)]
        public short? Carga_de_Trabajo { get; set; }
        public string Nombre_Remitente { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public int? Agencia { get; set; }
        public string AgenciaDescripcion { get; set; }
        public int? Especialidad { get; set; }
        public string EspecialidadDescripcion { get; set; }
        public string ID_de_Dispositivo { get; set; }
        public string ID_de_Huella { get; set; }
        [Range(0, 9999999999)]
        public short? Fotografia { get; set; }
        [Range(0, 9999999999)]
        public int? Usuario_que_Registra { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public string Estatus_de_Registro { get; set; }

    }


}

