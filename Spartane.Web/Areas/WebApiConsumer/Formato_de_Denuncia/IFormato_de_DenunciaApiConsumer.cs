﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Formato_de_Denuncia
{
    public interface IFormato_de_DenunciaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_DenunciaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Formato_de_DenunciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia entity, Spartane.Core.Domain.User.GlobalData Formato_de_DenunciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia entity, Spartane.Core.Domain.User.GlobalData Formato_de_DenunciaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_DenunciaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Formato_de_Denuncia.Formato_de_Denuncia_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

