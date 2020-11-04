﻿using System;
using Spartane.Core.Domain.Etnia;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Etnia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEtniaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Etnia.Etnia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Etnia.Etnia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Etnia.Etnia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Etnia.Etnia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Etnia.Etnia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Etnia.Etnia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Etnia.Etnia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Etnia.Etnia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Etnia.EtniaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Etnia.Etnia> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
