﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Aseguramiento_DocumentosGridModel
    {
        public int Clave { get; set; }
        public string Tipo { get; set; }
        public decimal? Cantidad { get; set; }
        public string Observaciones { get; set; }
        public string Descipcion_de_Documento { get; set; }
        
    }
}

