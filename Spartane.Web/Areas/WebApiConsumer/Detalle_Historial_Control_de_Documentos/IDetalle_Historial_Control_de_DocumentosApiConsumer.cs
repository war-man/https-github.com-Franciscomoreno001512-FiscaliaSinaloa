﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Historial_Control_de_Documentos
{
    public interface IDetalle_Historial_Control_de_DocumentosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_DocumentosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Historial_Control_de_DocumentosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos entity, Spartane.Core.Domain.User.GlobalData Detalle_Historial_Control_de_DocumentosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos entity, Spartane.Core.Domain.User.GlobalData Detalle_Historial_Control_de_DocumentosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_DocumentosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Detalle_Historial_Control_de_Documentos.Detalle_Historial_Control_de_Documentos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

