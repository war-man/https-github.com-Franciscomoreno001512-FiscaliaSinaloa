﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_de_Folio_Asignado_de_Usuario
{
    public interface IDetalle_de_Folio_Asignado_de_UsuarioApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_UsuarioPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario entity, Spartane.Core.Domain.User.GlobalData Detalle_de_Folio_Asignado_de_UsuarioInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_UsuarioPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_de_Folio_Asignado_de_Usuario.Detalle_de_Folio_Asignado_de_Usuario_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

