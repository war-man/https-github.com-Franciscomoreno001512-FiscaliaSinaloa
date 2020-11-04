﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Otros_Nombres_Requerido_MASC;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Otros_Nombres_Requerido_MASC
{
    public class Otros_Nombres_Requerido_MASCApiConsumer : BaseApiConsumer,IOtros_Nombres_Requerido_MASCApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Otros_Nombres_Requerido_MASCApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Otros_Nombres_Requerido_MASC";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>(false, null);
            }
        }

        public ApiResponse<Otros_Nombres_Requerido_MASCPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Otros_Nombres_Requerido_MASC.Clave='" + Key.ToString() + "'"
                        + "&Order=Otros_Nombres_Requerido_MASC.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(false, new Otros_Nombres_Requerido_MASCPagingModel() { Otros_Nombres_Requerido_MASCs = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Otros_Nombres_Requerido_MASCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC entity, Core.Domain.User.GlobalData Otros_Nombres_Requerido_MASCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC entity, Core.Domain.User.GlobalData Otros_Nombres_Requerido_MASCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Otros_Nombres_Requerido_MASCPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASCPagingModel>(false, new Otros_Nombres_Requerido_MASCPagingModel() { Otros_Nombres_Requerido_MASCs = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Otros_Nombres_Requerido_MASCGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Otros_Nombres_Requerido_MASC_Datos_Generales entity)
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

        public ApiResponse<Otros_Nombres_Requerido_MASC_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Otros_Nombres_Requerido_MASC.Otros_Nombres_Requerido_MASC_Datos_Generales>(false, null);
            }
        }


    }
}

