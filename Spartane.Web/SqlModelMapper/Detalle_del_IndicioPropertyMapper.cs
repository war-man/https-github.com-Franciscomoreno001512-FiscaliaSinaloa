﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_del_Indicio;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_del_IndicioPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Detalle_del_Indicio.Clave";
                case "Numero_de_Indicio":
                    return "Detalle_del_Indicio.Numero_de_Indicio";
                case "Nombre_del_Indicio":
                    return "Detalle_del_Indicio.Nombre_del_Indicio";
                case "Descripcion_del_Indicio":
                    return "Detalle_del_Indicio.Descripcion_del_Indicio";
                case "Motivo":
                    return "Detalle_del_Indicio.Motivo";
                case "Estatus[Descripcion]":
                case "EstatusDescripcion":
                    return "Estatus_de_Indicio.Descripcion";
                case "Ubicacion_de_Indicio":
                    return "Detalle_del_Indicio.Ubicacion_de_Indicio";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_del_Indicio).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {


            var operatorCondition = GetOperationType(columnName);
            columnName = GetPropertyName(columnName);

            switch (operatorCondition)
            {
                case SqlOperationType.Contains:
                    return string.IsNullOrEmpty(Convert.ToString(value)) ? "" : columnName + " LIKE '%" + value + "%'";
                case SqlOperationType.Equals:
                    return Convert.ToString(value) == "0" || Convert.ToString(value) == "" ? "" : columnName + "='" + value + "'";

            }
            return null;
        }
    }
}

