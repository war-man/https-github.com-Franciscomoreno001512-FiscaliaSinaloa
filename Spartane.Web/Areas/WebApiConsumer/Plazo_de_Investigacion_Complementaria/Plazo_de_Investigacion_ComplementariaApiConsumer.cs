﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Plazo_de_Investigacion_Complementaria
{
    public class Plazo_de_Investigacion_ComplementariaApiConsumer : BaseApiConsumer,IPlazo_de_Investigacion_ComplementariaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Plazo_de_Investigacion_ComplementariaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Plazo_de_Investigacion_Complementaria";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>(false, null);
            }
        }

        public ApiResponse<Plazo_de_Investigacion_ComplementariaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Plazo_de_Investigacion_Complementaria.Clave='" + Key.ToString() + "'"
                        + "&Order=Plazo_de_Investigacion_Complementaria.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(false, new Plazo_de_Investigacion_ComplementariaPagingModel() { Plazo_de_Investigacion_Complementarias = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Plazo_de_Investigacion_ComplementariaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria entity, Core.Domain.User.GlobalData Plazo_de_Investigacion_ComplementariaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria entity, Core.Domain.User.GlobalData Plazo_de_Investigacion_ComplementariaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Plazo_de_Investigacion_ComplementariaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_ComplementariaPagingModel>(false, new Plazo_de_Investigacion_ComplementariaPagingModel() { Plazo_de_Investigacion_Complementarias = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Plazo_de_Investigacion_ComplementariaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Plazo_de_Investigacion_Complementaria_Datos_Generales entity)
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

        public ApiResponse<Plazo_de_Investigacion_Complementaria_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Plazo_de_Investigacion_Complementaria.Plazo_de_Investigacion_Complementaria_Datos_Generales>(false, null);
            }
        }


    }
}

