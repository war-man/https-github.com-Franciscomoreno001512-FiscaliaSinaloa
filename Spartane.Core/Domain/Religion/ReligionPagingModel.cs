﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Religion
{
    public class ReligionPagingModel
    {
        public List<Spartane.Core.Domain.Religion.Religion> Religions { set; get; }
        public int RowCount { set; get; }
    }
}
