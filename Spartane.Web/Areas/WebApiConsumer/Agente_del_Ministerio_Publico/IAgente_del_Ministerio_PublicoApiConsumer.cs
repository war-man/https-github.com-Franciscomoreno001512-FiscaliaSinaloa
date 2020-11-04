﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Agente_del_Ministerio_Publico
{
    public interface IAgente_del_Ministerio_PublicoApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_PublicoPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Agente_del_Ministerio_PublicoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico entity, Spartane.Core.Domain.User.GlobalData Agente_del_Ministerio_PublicoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico entity, Spartane.Core.Domain.User.GlobalData Agente_del_Ministerio_PublicoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_PublicoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Agente_del_Ministerio_Publico.Agente_del_Ministerio_Publico_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

