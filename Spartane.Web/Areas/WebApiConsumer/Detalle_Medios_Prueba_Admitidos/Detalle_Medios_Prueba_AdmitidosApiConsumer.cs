﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Medios_Prueba_Admitidos
{
    public class Detalle_Medios_Prueba_AdmitidosApiConsumer : BaseApiConsumer,IDetalle_Medios_Prueba_AdmitidosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Detalle_Medios_Prueba_AdmitidosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Detalle_Medios_Prueba_Admitidos";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>(false, null);
            }
        }

        public ApiResponse<Detalle_Medios_Prueba_AdmitidosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Detalle_Medios_Prueba_Admitidos.Clave='" + Key.ToString() + "'"
                        + "&Order=Detalle_Medios_Prueba_Admitidos.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(false, new Detalle_Medios_Prueba_AdmitidosPagingModel() { Detalle_Medios_Prueba_Admitidoss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Detalle_Medios_Prueba_AdmitidosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos entity, Core.Domain.User.GlobalData Detalle_Medios_Prueba_AdmitidosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos entity, Core.Domain.User.GlobalData Detalle_Medios_Prueba_AdmitidosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Detalle_Medios_Prueba_AdmitidosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_AdmitidosPagingModel>(false, new Detalle_Medios_Prueba_AdmitidosPagingModel() { Detalle_Medios_Prueba_Admitidoss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Detalle_Medios_Prueba_AdmitidosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Detalle_Medios_Prueba_Admitidos_Datos_Generales entity)
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

        public ApiResponse<Detalle_Medios_Prueba_Admitidos_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Medios_Prueba_Admitidos.Detalle_Medios_Prueba_Admitidos_Datos_Generales>(false, null);
            }
        }


    }
}

