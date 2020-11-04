﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Jefes_de_Usuarios_del_Sistema
{
    public interface IJefes_de_Usuarios_del_SistemaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_SistemaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Jefes_de_Usuarios_del_SistemaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema entity, Spartane.Core.Domain.User.GlobalData Jefes_de_Usuarios_del_SistemaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema entity, Spartane.Core.Domain.User.GlobalData Jefes_de_Usuarios_del_SistemaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_SistemaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Jefes_de_Usuarios_del_Sistema.Jefes_de_Usuarios_del_Sistema_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

