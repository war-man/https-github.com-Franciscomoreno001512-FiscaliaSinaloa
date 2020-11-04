﻿using System;
using Spartane.Core.Domain.Spartan_Attribute_Bypass;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Attribute_Bypass
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Attribute_BypassService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_BypassPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Attribute_Bypass.Spartan_Attribute_Bypass> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
