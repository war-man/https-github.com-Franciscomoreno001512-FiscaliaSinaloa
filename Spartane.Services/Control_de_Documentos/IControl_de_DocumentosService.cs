﻿using System;
using Spartane.Core.Domain.Control_de_Documentos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Control_de_Documentos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IControl_de_DocumentosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Control_de_Documentos.Control_de_DocumentosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Control_de_Documentos.Control_de_Documentos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
