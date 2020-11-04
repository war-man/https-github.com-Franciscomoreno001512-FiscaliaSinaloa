﻿using System;
using Spartane.Core.Domain.Identificacion;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Identificacion
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IIdentificacionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Identificacion.Identificacion> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Identificacion.Identificacion> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Identificacion.Identificacion> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Identificacion.Identificacion GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Identificacion.Identificacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Identificacion.Identificacion entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Identificacion.Identificacion> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Identificacion.Identificacion> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Identificacion.IdentificacionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Identificacion.Identificacion> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
