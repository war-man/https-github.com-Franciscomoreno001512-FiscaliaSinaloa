﻿using System;
using Spartane.Core.Domain.Plazo_Constitucional;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Plazo_Constitucional
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPlazo_ConstitucionalService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Plazo_Constitucional.Plazo_ConstitucionalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Plazo_Constitucional.Plazo_Constitucional> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
