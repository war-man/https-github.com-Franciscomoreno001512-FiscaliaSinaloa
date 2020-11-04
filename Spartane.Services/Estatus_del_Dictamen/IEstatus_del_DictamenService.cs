﻿using System;
using Spartane.Core.Domain.Estatus_del_Dictamen;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_del_Dictamen
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_del_DictamenService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_DictamenPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_del_Dictamen.Estatus_del_Dictamen> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
