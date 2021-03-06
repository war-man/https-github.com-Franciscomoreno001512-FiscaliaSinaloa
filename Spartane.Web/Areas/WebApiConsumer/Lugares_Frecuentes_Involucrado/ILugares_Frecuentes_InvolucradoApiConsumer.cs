﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Lugares_Frecuentes_Involucrado
{
    public interface ILugares_Frecuentes_InvolucradoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_InvolucradoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_InvolucradoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado entity, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_InvolucradoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado entity, Spartane.Core.Domain.User.GlobalData Lugares_Frecuentes_InvolucradoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_InvolucradoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Lugares_Frecuentes_Involucrado.Lugares_Frecuentes_Involucrado_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

