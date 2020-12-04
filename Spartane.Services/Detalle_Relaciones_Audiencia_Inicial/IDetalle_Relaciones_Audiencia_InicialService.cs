﻿using System;
using Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Relaciones_Audiencia_Inicial
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Relaciones_Audiencia_InicialService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_InicialPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Relaciones_Audiencia_Inicial.Detalle_Relaciones_Audiencia_Inicial> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
