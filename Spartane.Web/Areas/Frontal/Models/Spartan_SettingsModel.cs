﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_SettingsModel
    {
        [Required]
        public string Clave { get; set; }
        public string Valor { get; set; }

    }
}

