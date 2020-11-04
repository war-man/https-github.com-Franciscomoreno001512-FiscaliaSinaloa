﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Detalle_de_Delito_de_Justicia;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_de_Delito_de_Justicia
{
    public class Detalle_de_Delito_de_JusticiaApiConsumer : BaseApiConsumer,IDetalle_de_Delito_de_JusticiaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Detalle_de_Delito_de_JusticiaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Detalle_de_Delito_de_Justicia";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>(false, null);
            }
        }

        public ApiResponse<Detalle_de_Delito_de_JusticiaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Detalle_de_Delito_de_Justicia.Clave='" + Key.ToString() + "'"
                        + "&Order=Detalle_de_Delito_de_Justicia.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(false, new Detalle_de_Delito_de_JusticiaPagingModel() { Detalle_de_Delito_de_Justicias = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Detalle_de_Delito_de_JusticiaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia entity, Core.Domain.User.GlobalData Detalle_de_Delito_de_JusticiaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia entity, Core.Domain.User.GlobalData Detalle_de_Delito_de_JusticiaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Detalle_de_Delito_de_JusticiaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_JusticiaPagingModel>(false, new Detalle_de_Delito_de_JusticiaPagingModel() { Detalle_de_Delito_de_Justicias = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Detalle_de_Delito_de_JusticiaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Detalle_de_Delito_de_Justicia_Datos_Generales entity)
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

        public ApiResponse<Detalle_de_Delito_de_Justicia_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_de_Robo_de_Vehiculo(Detalle_de_Delito_de_Justicia_Datos_de_Robo_de_Vehiculo entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_de_Robo_de_Vehiculo",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Detalle_de_Delito_de_Justicia_Datos_de_Robo_de_Vehiculo> Get_Datos_de_Robo_de_Vehiculo(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_de_Robo_de_Vehiculo>(baseApi, ApiControllerUrl + "/Get_Datos_de_Robo_de_Vehiculo?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_de_Robo_de_Vehiculo>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Datos_de_Robo_de_Vehiculo>(false, null);
            }
        }

public ApiResponse<int> Update_Asignar_Dueno(Detalle_de_Delito_de_Justicia_Asignar_Dueno entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Asignar_Dueno",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Detalle_de_Delito_de_Justicia_Asignar_Dueno> Get_Asignar_Dueno(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Asignar_Dueno>(baseApi, ApiControllerUrl + "/Get_Asignar_Dueno?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Asignar_Dueno>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_de_Delito_de_Justicia.Detalle_de_Delito_de_Justicia_Asignar_Dueno>(false, null);
            }
        }


    }
}

