﻿using System;
using Spartane.Core.Domain.Dashboard_Editor;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Dashboard_Editor
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDashboard_EditorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Dashboard_Editor.Dashboard_EditorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Dashboard_Editor.Dashboard_Editor> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
