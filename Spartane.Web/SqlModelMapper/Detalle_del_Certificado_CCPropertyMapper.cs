﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Detalle_del_Certificado_CC;

namespace Spartane.Web.SqlModelMapper
{
    public class Detalle_del_Certificado_CCPropertyMapper : ISqlPropertyMapper
    {
        public string GetPropertyName(string propertyName)
        {
            switch (propertyName)
            {
                case "Clave":
                    return "Detalle_del_Certificado_CC.Clave";
                case "Certificado":
                    return "Detalle_del_Certificado_CC.Certificado";
                case "Archivo":
                    return "Detalle_del_Certificado_CC.Archivo";
                case "Fecha":
                    return "Detalle_del_Certificado_CC.Fecha";

                default:
                    return propertyName;
            }
        }

        public SqlOperationType GetOperationType(string columnName)
        {
            var t = (typeof(Detalle_del_Certificado_CC).GetProperty(columnName));
            if ( t !=null && t.PropertyType.FullName.Contains(typeof(System.DateTime).Name))
                return SqlOperationType.Equals;
            else return SqlOperationType.Contains;
        }


        public string GetOperatorString(object value, string columnName)
        {
            if (columnName == "Fecha")
            {
                try
                {
                    value = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {

                }
            }


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

