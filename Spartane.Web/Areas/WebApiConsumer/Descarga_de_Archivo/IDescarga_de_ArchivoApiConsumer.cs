﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Descarga_de_Archivo
{
    public interface IDescarga_de_ArchivoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_ArchivoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Descarga_de_ArchivoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo entity, Spartane.Core.Domain.User.GlobalData Descarga_de_ArchivoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo entity, Spartane.Core.Domain.User.GlobalData Descarga_de_ArchivoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_ArchivoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Descarga_de_Archivo.Descarga_de_Archivo_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

