﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Unidad_de_Medida_de_pirateria;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Unidad_de_Medida_de_pirateria
{
    public class Unidad_de_Medida_de_pirateriaApiConsumer : BaseApiConsumer,IUnidad_de_Medida_de_pirateriaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Unidad_de_Medida_de_pirateriaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Unidad_de_Medida_de_pirateria";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>(false, null);
            }
        }

        public ApiResponse<Unidad_de_Medida_de_pirateriaPagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Unidad_de_Medida_de_pirateria.Clave='" + Key.ToString() + "'"
                        + "&Order=Unidad_de_Medida_de_pirateria.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(false, new Unidad_de_Medida_de_pirateriaPagingModel() { Unidad_de_Medida_de_piraterias = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Unidad_de_Medida_de_pirateriaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria entity, Core.Domain.User.GlobalData Unidad_de_Medida_de_pirateriaInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<short> Update(Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria entity, Core.Domain.User.GlobalData Unidad_de_Medida_de_pirateriaInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Clave,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Unidad_de_Medida_de_pirateriaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateriaPagingModel>(false, new Unidad_de_Medida_de_pirateriaPagingModel() { Unidad_de_Medida_de_piraterias = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<short> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Unidad_de_Medida_de_pirateriaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }
		
public ApiResponse<short> Update_Datos_Generales(Unidad_de_Medida_de_pirateria_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<Unidad_de_Medida_de_pirateria_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Unidad_de_Medida_de_pirateria.Unidad_de_Medida_de_pirateria_Datos_Generales>(false, null);
            }
        }


    }
}

