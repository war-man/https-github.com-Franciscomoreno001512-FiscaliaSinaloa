﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Tipo_de_Seguimiento
{
    public class Tipo_de_SeguimientoPagingModel
    {
        public List<Spartane.Core.Domain.Tipo_de_Seguimiento.Tipo_de_Seguimiento> Tipo_de_Seguimientos { set; get; }
        public int RowCount { set; get; }
    }
}
