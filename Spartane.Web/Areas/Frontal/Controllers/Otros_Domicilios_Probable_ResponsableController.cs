﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Otros_Domicilios_Probable_Responsable;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Municipio;
using Spartane.Core.Domain.Colonia;
using Spartane.Core.Domain.Colonia;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Otros_Domicilios_Probable_Responsable;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Otros_Domicilios_Probable_Responsable;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Municipio;
using Spartane.Web.Areas.WebApiConsumer.Colonia;
using Spartane.Web.Areas.WebApiConsumer.Colonia;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Otros_Domicilios_Probable_ResponsableController : Controller
    {
        #region "variable declaration"

        private IOtros_Domicilios_Probable_ResponsableService service = null;
        private IOtros_Domicilios_Probable_ResponsableApiConsumer _IOtros_Domicilios_Probable_ResponsableApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private IMunicipioApiConsumer _IMunicipioApiConsumer;
        private IColoniaApiConsumer _IColoniaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Otros_Domicilios_Probable_ResponsableController(IOtros_Domicilios_Probable_ResponsableService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IOtros_Domicilios_Probable_ResponsableApiConsumer Otros_Domicilios_Probable_ResponsableApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IEstadoApiConsumer EstadoApiConsumer , IMunicipioApiConsumer MunicipioApiConsumer , IColoniaApiConsumer ColoniaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IOtros_Domicilios_Probable_ResponsableApiConsumer = Otros_Domicilios_Probable_ResponsableApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IMunicipioApiConsumer = MunicipioApiConsumer;
            this._IColoniaApiConsumer = ColoniaApiConsumer;
            this._IColoniaApiConsumer = ColoniaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Otros_Domicilios_Probable_Responsable
        [ObjectAuth(ObjectId = (ModuleObjectId)45300, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45300);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Otros_Domicilios_Probable_Responsable/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)45300, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45300);
            ViewBag.Permission = permission;
            var varOtros_Domicilios_Probable_Responsable = new Otros_Domicilios_Probable_ResponsableModel();
			
            ViewBag.ObjectId = "45300";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Otros_Domicilios_Probable_ResponsableData = _IOtros_Domicilios_Probable_ResponsableApiConsumer.GetByKeyComplete(Id).Resource.Otros_Domicilios_Probable_Responsables[0];
                if (Otros_Domicilios_Probable_ResponsableData == null)
                    return HttpNotFound();

                varOtros_Domicilios_Probable_Responsable = new Otros_Domicilios_Probable_ResponsableModel
                {
                    Clave = (int)Otros_Domicilios_Probable_ResponsableData.Clave
                    ,Estado = Otros_Domicilios_Probable_ResponsableData.Estado
                    ,EstadoNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Estado), "Estado") ??  (string)Otros_Domicilios_Probable_ResponsableData.Estado_Estado.Nombre
                    ,Municipio = Otros_Domicilios_Probable_ResponsableData.Municipio
                    ,MunicipioNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Municipio), "Municipio") ??  (string)Otros_Domicilios_Probable_ResponsableData.Municipio_Municipio.Nombre
                    ,Poblacion = Otros_Domicilios_Probable_ResponsableData.Poblacion
                    ,PoblacionNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Poblacion), "Colonia") ??  (string)Otros_Domicilios_Probable_ResponsableData.Poblacion_Colonia.Nombre
                    ,Colonia = Otros_Domicilios_Probable_ResponsableData.Colonia
                    ,ColoniaNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Colonia), "Colonia") ??  (string)Otros_Domicilios_Probable_ResponsableData.Colonia_Colonia.Nombre
                    ,Codigo_Postal = Otros_Domicilios_Probable_ResponsableData.Codigo_Postal
                    ,Calle = Otros_Domicilios_Probable_ResponsableData.Calle
                    ,Entre_Calle = Otros_Domicilios_Probable_ResponsableData.Entre_Calle
                    ,Y_Calle = Otros_Domicilios_Probable_ResponsableData.Y_Calle
                    ,Numero_Exterior = Otros_Domicilios_Probable_ResponsableData.Numero_Exterior

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varOtros_Domicilios_Probable_Responsable);
        }
		
	[HttpGet]
        public ActionResult AddOtros_Domicilios_Probable_Responsable(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45300);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);
			Otros_Domicilios_Probable_ResponsableModel varOtros_Domicilios_Probable_Responsable= new Otros_Domicilios_Probable_ResponsableModel();


            if (id.ToString() != "0")
            {
                var Otros_Domicilios_Probable_ResponsablesData = _IOtros_Domicilios_Probable_ResponsableApiConsumer.ListaSelAll(0, 1000, "Otros_Domicilios_Probable_Responsable.Clave=" + id, "").Resource.Otros_Domicilios_Probable_Responsables;
				
				if (Otros_Domicilios_Probable_ResponsablesData != null && Otros_Domicilios_Probable_ResponsablesData.Count > 0)
                {
					var Otros_Domicilios_Probable_ResponsableData = Otros_Domicilios_Probable_ResponsablesData.First();
					varOtros_Domicilios_Probable_Responsable= new Otros_Domicilios_Probable_ResponsableModel
					{
						Clave  = Otros_Domicilios_Probable_ResponsableData.Clave 
	                    ,Estado = Otros_Domicilios_Probable_ResponsableData.Estado
                    ,EstadoNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Estado), "Estado") ??  (string)Otros_Domicilios_Probable_ResponsableData.Estado_Estado.Nombre
                    ,Municipio = Otros_Domicilios_Probable_ResponsableData.Municipio
                    ,MunicipioNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Municipio), "Municipio") ??  (string)Otros_Domicilios_Probable_ResponsableData.Municipio_Municipio.Nombre
                    ,Poblacion = Otros_Domicilios_Probable_ResponsableData.Poblacion
                    ,PoblacionNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Poblacion), "Colonia") ??  (string)Otros_Domicilios_Probable_ResponsableData.Poblacion_Colonia.Nombre
                    ,Colonia = Otros_Domicilios_Probable_ResponsableData.Colonia
                    ,ColoniaNombre = CultureHelper.GetTraduction(Convert.ToString(Otros_Domicilios_Probable_ResponsableData.Colonia), "Colonia") ??  (string)Otros_Domicilios_Probable_ResponsableData.Colonia_Colonia.Nombre
                    ,Codigo_Postal = Otros_Domicilios_Probable_ResponsableData.Codigo_Postal
                    ,Calle = Otros_Domicilios_Probable_ResponsableData.Calle
                    ,Entre_Calle = Otros_Domicilios_Probable_ResponsableData.Entre_Calle
                    ,Y_Calle = Otros_Domicilios_Probable_ResponsableData.Y_Calle
                    ,Numero_Exterior = Otros_Domicilios_Probable_ResponsableData.Numero_Exterior

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddOtros_Domicilios_Probable_Responsable", varOtros_Domicilios_Probable_Responsable);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

		[HttpGet]
        public ActionResult GetEstadoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstadoApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetMunicipioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMunicipioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMunicipioApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Municipio", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetColoniaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IColoniaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IColoniaApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Colonia", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Domicilios_Probable_ResponsablePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IOtros_Domicilios_Probable_ResponsableApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Domicilios_Probable_Responsables == null)
                result.Otros_Domicilios_Probable_Responsables = new List<Otros_Domicilios_Probable_Responsable>();

            return Json(new
            {
                data = result.Otros_Domicilios_Probable_Responsables.Select(m => new Otros_Domicilios_Probable_ResponsableGridModel
                    {
                    Clave = m.Clave
                        ,EstadoNombre = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Estado") ?? (string)m.Estado_Estado.Nombre
                        ,MunicipioNombre = CultureHelper.GetTraduction(m.Municipio_Municipio.Clave.ToString(), "Municipio") ?? (string)m.Municipio_Municipio.Nombre
                        ,PoblacionNombre = CultureHelper.GetTraduction(m.Poblacion_Colonia.Clave.ToString(), "Colonia") ?? (string)m.Poblacion_Colonia.Nombre
                        ,ColoniaNombre = CultureHelper.GetTraduction(m.Colonia_Colonia.Clave.ToString(), "Colonia") ?? (string)m.Colonia_Colonia.Nombre
			,Codigo_Postal = m.Codigo_Postal
			,Calle = m.Calle
			,Entre_Calle = m.Entre_Calle
			,Y_Calle = m.Y_Calle
			,Numero_Exterior = m.Numero_Exterior

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetOtros_Domicilios_Probable_Responsable_Estado_Estado(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Estado.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Estado.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IEstadoApiConsumer.ListaSelAll(1, 20,elWhere , " Estado.Nombre ASC ").Resource;
               
                foreach (var item in result.Estados)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estado", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Estados.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetOtros_Domicilios_Probable_Responsable_Municipio_Municipio(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMunicipioApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Municipio.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Municipio.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IMunicipioApiConsumer.ListaSelAll(1, 20,elWhere , " Municipio.Nombre ASC ").Resource;
               
                foreach (var item in result.Municipios)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Municipio", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Municipios.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetOtros_Domicilios_Probable_Responsable_Poblacion_Colonia(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IColoniaApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Colonia.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Colonia.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IColoniaApiConsumer.ListaSelAll(1, 20,elWhere , " Colonia.Nombre ASC ").Resource;
               
                foreach (var item in result.Colonias)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Colonia", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Colonias.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetOtros_Domicilios_Probable_Responsable_Colonia_Colonia(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IColoniaApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Colonia.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Colonia.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IColoniaApiConsumer.ListaSelAll(1, 20,elWhere , " Colonia.Nombre ASC ").Resource;
               
                foreach (var item in result.Colonias)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Colonia", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Colonias.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





       

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);

                Otros_Domicilios_Probable_Responsable varOtros_Domicilios_Probable_Responsable = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IOtros_Domicilios_Probable_ResponsableApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Otros_Domicilios_Probable_ResponsableModel varOtros_Domicilios_Probable_Responsable)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Otros_Domicilios_Probable_ResponsableInfo = new Otros_Domicilios_Probable_Responsable
                    {
                        Clave = varOtros_Domicilios_Probable_Responsable.Clave
                        ,Estado = varOtros_Domicilios_Probable_Responsable.Estado
                        ,Municipio = varOtros_Domicilios_Probable_Responsable.Municipio
                        ,Poblacion = varOtros_Domicilios_Probable_Responsable.Poblacion
                        ,Colonia = varOtros_Domicilios_Probable_Responsable.Colonia
                        ,Codigo_Postal = varOtros_Domicilios_Probable_Responsable.Codigo_Postal
                        ,Calle = varOtros_Domicilios_Probable_Responsable.Calle
                        ,Entre_Calle = varOtros_Domicilios_Probable_Responsable.Entre_Calle
                        ,Y_Calle = varOtros_Domicilios_Probable_Responsable.Y_Calle
                        ,Numero_Exterior = varOtros_Domicilios_Probable_Responsable.Numero_Exterior

                    };

                    result = !IsNew ?
                        _IOtros_Domicilios_Probable_ResponsableApiConsumer.Update(Otros_Domicilios_Probable_ResponsableInfo, null, null).Resource.ToString() :
                         _IOtros_Domicilios_Probable_ResponsableApiConsumer.Insert(Otros_Domicilios_Probable_ResponsableInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Otros_Domicilios_Probable_Responsable script
        /// </summary>
        /// <param name="oOtros_Domicilios_Probable_ResponsableElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Otros_Domicilios_Probable_ResponsableModuleAttributeList)
        {
            for (int i = 0; i < Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strOtros_Domicilios_Probable_ResponsableScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Otros_Domicilios_Probable_Responsable.js")))
            {
                strOtros_Domicilios_Probable_ResponsableScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Otros_Domicilios_Probable_Responsable element attributes
            string userChangeJson = jsSerialize.Serialize(Otros_Domicilios_Probable_ResponsableModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strOtros_Domicilios_Probable_ResponsableScript.IndexOf("inpuElementArray");
            string splittedString = strOtros_Domicilios_Probable_ResponsableScript.Substring(indexOfArray, strOtros_Domicilios_Probable_ResponsableScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strOtros_Domicilios_Probable_ResponsableScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strOtros_Domicilios_Probable_ResponsableScript.Substring(indexOfArrayHistory, strOtros_Domicilios_Probable_ResponsableScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strOtros_Domicilios_Probable_ResponsableScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strOtros_Domicilios_Probable_ResponsableScript.Substring(endIndexOfMainElement + indexOfArray, strOtros_Domicilios_Probable_ResponsableScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Otros_Domicilios_Probable_ResponsableModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strOtros_Domicilios_Probable_ResponsableScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strOtros_Domicilios_Probable_ResponsableScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strOtros_Domicilios_Probable_ResponsableScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strOtros_Domicilios_Probable_ResponsableScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Otros_Domicilios_Probable_Responsable.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Otros_Domicilios_Probable_Responsable.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Otros_Domicilios_Probable_Responsable.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Otros_Domicilios_Probable_ResponsablePropertyBag()
        {
            return PartialView("Otros_Domicilios_Probable_ResponsablePropertyBag", "Otros_Domicilios_Probable_Responsable");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Domicilios_Probable_ResponsablePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IOtros_Domicilios_Probable_ResponsableApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Domicilios_Probable_Responsables == null)
                result.Otros_Domicilios_Probable_Responsables = new List<Otros_Domicilios_Probable_Responsable>();

            var data = result.Otros_Domicilios_Probable_Responsables.Select(m => new Otros_Domicilios_Probable_ResponsableGridModel
            {
                Clave = m.Clave
                ,EstadoNombre = (string)m.Estado_Estado.Nombre
                ,MunicipioNombre = (string)m.Municipio_Municipio.Nombre
                ,PoblacionNombre = (string)m.Poblacion_Colonia.Nombre
                ,ColoniaNombre = (string)m.Colonia_Colonia.Nombre
                ,Codigo_Postal = m.Codigo_Postal
                ,Calle = m.Calle
                ,Entre_Calle = m.Entre_Calle
                ,Y_Calle = m.Y_Calle
                ,Numero_Exterior = m.Numero_Exterior

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Otros_Domicilios_Probable_ResponsableList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Otros_Domicilios_Probable_ResponsableList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IOtros_Domicilios_Probable_ResponsableApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Domicilios_Probable_ResponsablePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IOtros_Domicilios_Probable_ResponsableApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Domicilios_Probable_Responsables == null)
                result.Otros_Domicilios_Probable_Responsables = new List<Otros_Domicilios_Probable_Responsable>();

            var data = result.Otros_Domicilios_Probable_Responsables.Select(m => new Otros_Domicilios_Probable_ResponsableGridModel
            {
                Clave = m.Clave
                ,EstadoNombre = (string)m.Estado_Estado.Nombre
                ,MunicipioNombre = (string)m.Municipio_Municipio.Nombre
                ,PoblacionNombre = (string)m.Poblacion_Colonia.Nombre
                ,ColoniaNombre = (string)m.Colonia_Colonia.Nombre
                ,Codigo_Postal = m.Codigo_Postal
                ,Calle = m.Calle
                ,Entre_Calle = m.Entre_Calle
                ,Y_Calle = m.Y_Calle
                ,Numero_Exterior = m.Numero_Exterior

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
