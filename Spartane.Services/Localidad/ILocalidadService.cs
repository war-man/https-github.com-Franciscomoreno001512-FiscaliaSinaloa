﻿using System;
using Spartane.Core.Domain.Localidad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Localidad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ILocalidadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Localidad.Localidad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Localidad.Localidad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Localidad.Localidad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Localidad.Localidad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Localidad.Localidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Localidad.Localidad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Localidad.Localidad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Localidad.Localidad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Localidad.LocalidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Localidad.Localidad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
