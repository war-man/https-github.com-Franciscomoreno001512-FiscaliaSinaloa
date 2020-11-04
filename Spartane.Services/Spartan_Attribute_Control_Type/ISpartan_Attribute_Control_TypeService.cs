﻿using System;
using Spartane.Core.Domain.Spartan_Attribute_Control_Type;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Attribute_Control_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Attribute_Control_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
