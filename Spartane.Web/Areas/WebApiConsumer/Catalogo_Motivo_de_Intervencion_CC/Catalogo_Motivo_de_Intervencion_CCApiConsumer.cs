﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Catalogo_Motivo_de_Intervencion_CC
{
    public class Catalogo_Motivo_de_Intervencion_CCApiConsumer : BaseApiConsumer,ICatalogo_Motivo_de_Intervencion_CCApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Catalogo_Motivo_de_Intervencion_CCApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Catalogo_Motivo_de_Intervencion_CC";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>(false, null);
            }
        }

        public ApiResponse<Catalogo_Motivo_de_Intervencion_CCPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Catalogo_Motivo_de_Intervencion_CC.Clave='" + Key.ToString() + "'"
                        + "&Order=Catalogo_Motivo_de_Intervencion_CC.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(false, new Catalogo_Motivo_de_Intervencion_CCPagingModel() { Catalogo_Motivo_de_Intervencion_CCs = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Catalogo_Motivo_de_Intervencion_CCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC entity, Core.Domain.User.GlobalData Catalogo_Motivo_de_Intervencion_CCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC entity, Core.Domain.User.GlobalData Catalogo_Motivo_de_Intervencion_CCInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Catalogo_Motivo_de_Intervencion_CCPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CCPagingModel>(false, new Catalogo_Motivo_de_Intervencion_CCPagingModel() { Catalogo_Motivo_de_Intervencion_CCs = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Catalogo_Motivo_de_Intervencion_CCGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Catalogo_Motivo_de_Intervencion_CC_Datos_Generales entity)
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

        public ApiResponse<Catalogo_Motivo_de_Intervencion_CC_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Catalogo_Motivo_de_Intervencion_CC.Catalogo_Motivo_de_Intervencion_CC_Datos_Generales>(false, null);
            }
        }


    }
}

