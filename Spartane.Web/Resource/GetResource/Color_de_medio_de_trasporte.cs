﻿using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Color_de_medio_de_trasporteResources
    {
        //private static IResourceProvider resourceProviderColor_de_medio_de_trasporte = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Color_de_medio_de_trasporteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderColor_de_medio_de_trasporte = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Color_de_medio_de_trasporteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderColor_de_medio_de_trasporte = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Color_de_medio_de_trasporteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Color_de_medio_de_trasporte</summary>
        public static string Color_de_medio_de_trasporte
        {
            get
            {
                SetPath();
                return resourceProviderColor_de_medio_de_trasporte.GetResource("Color_de_medio_de_trasporte", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderColor_de_medio_de_trasporte.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderColor_de_medio_de_trasporte.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderColor_de_medio_de_trasporte.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
