﻿using System;
using Spartane.Core.Domain.Tipo_de_Equipo_Tactico;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_de_Equipo_Tactico
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_de_Equipo_TacticoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_TacticoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_de_Equipo_Tactico.Tipo_de_Equipo_Tactico> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
