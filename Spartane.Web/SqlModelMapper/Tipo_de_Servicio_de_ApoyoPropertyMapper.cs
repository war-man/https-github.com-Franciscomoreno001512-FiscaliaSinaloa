﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Tipo_de_Servicio_de_Apoyo;

namespace Spartane.Web.SqlModelMapper
{
    public class Tipo_de_Servicio_de_ApoyoPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Tipo_de_Servicio_de_Apoyo.Clave";
                case "Servicio":
                    return "Tipo_de_Servicio_de_Apoyo.Servicio";
                case "Categoria[Descripcion]":
                case "CategoriaDescripcion":
                    return "Categoria_de_Servicio_de_Apoyo.Descripcion";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Tipo_de_Servicio_de_Apoyo).GetProperty(columnName));
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

