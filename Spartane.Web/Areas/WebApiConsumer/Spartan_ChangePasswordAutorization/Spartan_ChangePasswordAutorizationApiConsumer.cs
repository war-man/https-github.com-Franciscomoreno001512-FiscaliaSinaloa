﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization
{
    public class Spartan_ChangePasswordAutorizationApiConsumer : BaseApiConsumer,ISpartan_ChangePasswordAutorizationApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_ChangePasswordAutorizationApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_ChangePasswordAutorization";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>(false, null);
            }
        }

        public ApiResponse<Spartan_ChangePasswordAutorizationPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_ChangePasswordAutorization.Clave='" + Key.ToString() + "'"
                        + "&Order=Spartan_ChangePasswordAutorization.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(false, new Spartan_ChangePasswordAutorizationPagingModel() { Spartan_ChangePasswordAutorizations = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Core.Domain.User.GlobalData Spartan_ChangePasswordAutorizationInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_ChangePasswordAutorizationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel>(false, new Spartan_ChangePasswordAutorizationPagingModel() { Spartan_ChangePasswordAutorizations = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

