﻿using System;
using Spartane.Core.Domain.Detalle_de_Relaciones;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_de_Relaciones
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_de_RelacionesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_RelacionesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_de_Relaciones.Detalle_de_Relaciones> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
