﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Medios_Alternativos
{
    public interface IMedios_AlternativosApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Medios_Alternativos.Medios_AlternativosPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Medios_AlternativosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos entity, Spartane.Core.Domain.User.GlobalData Medios_AlternativosInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos entity, Spartane.Core.Domain.User.GlobalData Medios_AlternativosInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Medios_Alternativos.Medios_AlternativosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Medios_Alternativos.Medios_Alternativos_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

