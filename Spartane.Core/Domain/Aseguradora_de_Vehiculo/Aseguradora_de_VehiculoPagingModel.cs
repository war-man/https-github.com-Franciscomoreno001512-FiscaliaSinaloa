﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Aseguradora_de_Vehiculo
{
    public class Aseguradora_de_VehiculoPagingModel
    {
        public List<Spartane.Core.Domain.Aseguradora_de_Vehiculo.Aseguradora_de_Vehiculo> Aseguradora_de_Vehiculos { set; get; }
        public int RowCount { set; get; }
    }
}
