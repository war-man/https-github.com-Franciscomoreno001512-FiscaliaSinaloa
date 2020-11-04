﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Tipo_de_Comparecencia
{
    public interface ITipo_de_ComparecenciaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_ComparecenciaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Tipo_de_ComparecenciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia entity, Spartane.Core.Domain.User.GlobalData Tipo_de_ComparecenciaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia entity, Spartane.Core.Domain.User.GlobalData Tipo_de_ComparecenciaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_ComparecenciaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Tipo_de_Comparecencia.Tipo_de_Comparecencia_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

