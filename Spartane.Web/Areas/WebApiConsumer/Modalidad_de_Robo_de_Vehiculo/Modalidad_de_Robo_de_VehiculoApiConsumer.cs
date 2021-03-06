﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Modalidad_de_Robo_de_Vehiculo
{
    public class Modalidad_de_Robo_de_VehiculoApiConsumer : BaseApiConsumer,IModalidad_de_Robo_de_VehiculoApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Modalidad_de_Robo_de_VehiculoApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Modalidad_de_Robo_de_Vehiculo";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>(false, null);
            }
        }

        public ApiResponse<Modalidad_de_Robo_de_VehiculoPagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Modalidad_de_Robo_de_Vehiculo.Clave='" + Key.ToString() + "'"
                        + "&Order=Modalidad_de_Robo_de_Vehiculo.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(false, new Modalidad_de_Robo_de_VehiculoPagingModel() { Modalidad_de_Robo_de_Vehiculos = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Modalidad_de_Robo_de_VehiculoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo entity, Core.Domain.User.GlobalData Modalidad_de_Robo_de_VehiculoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Update(Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo entity, Core.Domain.User.GlobalData Modalidad_de_Robo_de_VehiculoInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Modalidad_de_Robo_de_VehiculoPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_VehiculoPagingModel>(false, new Modalidad_de_Robo_de_VehiculoPagingModel() { Modalidad_de_Robo_de_Vehiculos = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<short> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Modalidad_de_Robo_de_VehiculoGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }
		
public ApiResponse<short> Update_Datos_Generales(Modalidad_de_Robo_de_Vehiculo_Datos_Generales entity)
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

        public ApiResponse<Modalidad_de_Robo_de_Vehiculo_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Modalidad_de_Robo_de_Vehiculo.Modalidad_de_Robo_de_Vehiculo_Datos_Generales>(false, null);
            }
        }


    }
}

