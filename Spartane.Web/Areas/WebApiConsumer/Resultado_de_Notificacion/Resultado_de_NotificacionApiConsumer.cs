﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Resultado_de_Notificacion;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Resultado_de_Notificacion
{
    public class Resultado_de_NotificacionApiConsumer : BaseApiConsumer,IResultado_de_NotificacionApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Resultado_de_NotificacionApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Resultado_de_Notificacion";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>(false, null);
            }
        }

        public ApiResponse<Resultado_de_NotificacionPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Resultado_de_Notificacion.Clave='" + Key.ToString() + "'"
                        + "&Order=Resultado_de_Notificacion.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(false, new Resultado_de_NotificacionPagingModel() { Resultado_de_Notificacions = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Resultado_de_NotificacionInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<int> Insert(Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion entity, Core.Domain.User.GlobalData Resultado_de_NotificacionInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion entity, Core.Domain.User.GlobalData Resultado_de_NotificacionInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Clave,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Resultado_de_NotificacionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_NotificacionPagingModel>(false, new Resultado_de_NotificacionPagingModel() { Resultado_de_Notificacions = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Resultado_de_NotificacionGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Resultado_de_Notificacion_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Resultado_de_Notificacion_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Resultado_de_Notificacion.Resultado_de_Notificacion_Datos_Generales>(false, null);
            }
        }


    }
}

