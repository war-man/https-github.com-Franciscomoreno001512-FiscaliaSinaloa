﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Resultado_de_Revision
{
    public interface IResultado_de_RevisionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_RevisionPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Resultado_de_RevisionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision entity, Spartane.Core.Domain.User.GlobalData Resultado_de_RevisionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision entity, Spartane.Core.Domain.User.GlobalData Resultado_de_RevisionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_RevisionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<short> GenerateID();
		ApiResponse<short> Update_Datos_Generales(Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Resultado_de_Revision.Resultado_de_Revision_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

