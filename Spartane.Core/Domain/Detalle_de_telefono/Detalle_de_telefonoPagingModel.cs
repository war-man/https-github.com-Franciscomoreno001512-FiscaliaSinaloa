﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_de_telefono
{
    public class Detalle_de_telefonoPagingModel
    {
        public List<Spartane.Core.Domain.Detalle_de_telefono.Detalle_de_telefono> Detalle_de_telefonos { set; get; }
        public int RowCount { set; get; }
    }
}
