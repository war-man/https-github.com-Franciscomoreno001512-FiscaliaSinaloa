﻿using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_de_Fotos_de_Emergencia_CCResources
    {
        //private static IResourceProvider resourceProviderDetalle_de_Fotos_de_Emergencia_CC = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_de_Fotos_de_Emergencia_CCResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_de_Fotos_de_Emergencia_CC = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_Fotos_de_Emergencia_CCResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_de_Fotos_de_Emergencia_CC = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_Fotos_de_Emergencia_CCResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_de_Fotos_de_Emergencia_CC</summary>
        public static string Detalle_de_Fotos_de_Emergencia_CC
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Detalle_de_Fotos_de_Emergencia_CC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha</summary>
        public static string Fecha
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Fecha", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora</summary>
        public static string Hora
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Hora", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Latitud</summary>
        public static string Latitud
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Latitud", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Longitud</summary>
        public static string Longitud
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("Longitud", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_de_Fotos_de_Emergencia_CC.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
