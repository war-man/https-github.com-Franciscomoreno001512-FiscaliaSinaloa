﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Frente
{
    public class FrentePagingModel
    {
        public List<Spartane.Core.Domain.Frente.Frente> Frentes { set; get; }
        public int RowCount { set; get; }
    }
}
