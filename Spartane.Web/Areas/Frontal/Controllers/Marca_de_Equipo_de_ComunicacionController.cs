﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Marca_de_Equipo_de_Comunicacion;
using Spartane.Core.Domain.Tipo_de_Equipo_de_Comunicacion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Marca_de_Equipo_de_Comunicacion;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Marca_de_Equipo_de_Comunicacion;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Equipo_de_Comunicacion;

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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Marca_de_Equipo_de_ComunicacionController : Controller
    {
        #region "variable declaration"

        private IMarca_de_Equipo_de_ComunicacionService service = null;
        private IMarca_de_Equipo_de_ComunicacionApiConsumer _IMarca_de_Equipo_de_ComunicacionApiConsumer;
        private ITipo_de_Equipo_de_ComunicacionApiConsumer _ITipo_de_Equipo_de_ComunicacionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Marca_de_Equipo_de_ComunicacionController(IMarca_de_Equipo_de_ComunicacionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMarca_de_Equipo_de_ComunicacionApiConsumer Marca_de_Equipo_de_ComunicacionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ITipo_de_Equipo_de_ComunicacionApiConsumer Tipo_de_Equipo_de_ComunicacionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMarca_de_Equipo_de_ComunicacionApiConsumer = Marca_de_Equipo_de_ComunicacionApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ITipo_de_Equipo_de_ComunicacionApiConsumer = Tipo_de_Equipo_de_ComunicacionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Marca_de_Equipo_de_Comunicacion
        [ObjectAuth(ObjectId = (ModuleObjectId)45520, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45520, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Marca_de_Equipo_de_Comunicacion/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)45520, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(short Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45520, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varMarca_de_Equipo_de_Comunicacion = new Marca_de_Equipo_de_ComunicacionModel();
			varMarca_de_Equipo_de_Comunicacion.Clave = Id;
			
            ViewBag.ObjectId = "45520";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Marca_de_Equipo_de_ComunicacionsData = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll(0, 1000, "Marca_de_Equipo_de_Comunicacion.Clave=" + Id, "").Resource.Marca_de_Equipo_de_Comunicacions;
				
				if (Marca_de_Equipo_de_ComunicacionsData != null && Marca_de_Equipo_de_ComunicacionsData.Count > 0)
                {
					var Marca_de_Equipo_de_ComunicacionData = Marca_de_Equipo_de_ComunicacionsData.First();
					varMarca_de_Equipo_de_Comunicacion= new Marca_de_Equipo_de_ComunicacionModel
					{
						Clave  = Marca_de_Equipo_de_ComunicacionData.Clave 
	                    ,Descripcion = Marca_de_Equipo_de_ComunicacionData.Descripcion
                    ,Tipo_de_Equipo = Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo
                    ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo), "Tipo_de_Equipo_de_Comunicacion") ??  (string)Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = _ITipo_de_Equipo_de_ComunicacionApiConsumer.SelAll(true);
            if (Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo != null && Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource != null)
                ViewBag.Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Equipo_de_Comunicacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var viewInEframe = false;
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			if (Request.QueryString["viewInEframe"] != null)
                viewInEframe = Convert.ToBoolean(Request.QueryString["viewInEframe"]);	
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;
			ViewBag.viewInEframe = viewInEframe;

				
            return View(varMarca_de_Equipo_de_Comunicacion);
        }
		
	[HttpGet]
        public ActionResult AddMarca_de_Equipo_de_Comunicacion(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45520);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
			Marca_de_Equipo_de_ComunicacionModel varMarca_de_Equipo_de_Comunicacion= new Marca_de_Equipo_de_ComunicacionModel();


            if (id.ToString() != "0")
            {
                var Marca_de_Equipo_de_ComunicacionsData = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll(0, 1000, "Marca_de_Equipo_de_Comunicacion.Clave=" + id, "").Resource.Marca_de_Equipo_de_Comunicacions;
				
				if (Marca_de_Equipo_de_ComunicacionsData != null && Marca_de_Equipo_de_ComunicacionsData.Count > 0)
                {
					var Marca_de_Equipo_de_ComunicacionData = Marca_de_Equipo_de_ComunicacionsData.First();
					varMarca_de_Equipo_de_Comunicacion= new Marca_de_Equipo_de_ComunicacionModel
					{
						Clave  = Marca_de_Equipo_de_ComunicacionData.Clave 
	                    ,Descripcion = Marca_de_Equipo_de_ComunicacionData.Descripcion
                    ,Tipo_de_Equipo = Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo
                    ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo), "Tipo_de_Equipo_de_Comunicacion") ??  (string)Marca_de_Equipo_de_ComunicacionData.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = _ITipo_de_Equipo_de_ComunicacionApiConsumer.SelAll(true);
            if (Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo != null && Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource != null)
                ViewBag.Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Equipo_de_Comunicacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMarca_de_Equipo_de_Comunicacion", varMarca_de_Equipo_de_Comunicacion);
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
        public ActionResult GetTipo_de_Equipo_de_ComunicacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_Equipo_de_ComunicacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Equipo_de_Comunicacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Marca_de_Equipo_de_ComunicacionAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = _ITipo_de_Equipo_de_ComunicacionApiConsumer.SelAll(true);
            if (Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo != null && Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource != null)
                ViewBag.Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Equipo_de_Comunicacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipo_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = _ITipo_de_Equipo_de_ComunicacionApiConsumer.SelAll(true);
            if (Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo != null && Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource != null)
                ViewBag.Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo = Tipo_de_Equipo_de_Comunicacions_Tipo_de_Equipo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Equipo_de_Comunicacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Marca_de_Equipo_de_ComunicacionAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Marca_de_Equipo_de_ComunicacionAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Marca_de_Equipo_de_ComunicacionAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Marca_de_Equipo_de_ComunicacionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Marca_de_Equipo_de_Comunicacions == null)
                result.Marca_de_Equipo_de_Comunicacions = new List<Marca_de_Equipo_de_Comunicacion>();

            return Json(new
            {
                data = result.Marca_de_Equipo_de_Comunicacions.Select(m => new Marca_de_Equipo_de_ComunicacionGridModel
                    {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetMarca_de_Equipo_de_ComunicacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Marca_de_Equipo_de_Comunicacion", m.),
                     Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Marca_de_Equipo_de_Comunicacion from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Marca_de_Equipo_de_Comunicacion Entity</returns>
        public ActionResult GetMarca_de_Equipo_de_ComunicacionList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Marca_de_Equipo_de_ComunicacionPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Marca_de_Equipo_de_ComunicacionAdvanceSearchModel))
                {
					var advanceFilter =
                    (Marca_de_Equipo_de_ComunicacionAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Marca_de_Equipo_de_ComunicacionPropertyMapper oMarca_de_Equipo_de_ComunicacionPropertyMapper = new Marca_de_Equipo_de_ComunicacionPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oMarca_de_Equipo_de_ComunicacionPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Marca_de_Equipo_de_Comunicacions == null)
                result.Marca_de_Equipo_de_Comunicacions = new List<Marca_de_Equipo_de_Comunicacion>();

            return Json(new
            {
                aaData = result.Marca_de_Equipo_de_Comunicacions.Select(m => new Marca_de_Equipo_de_ComunicacionGridModel
            {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Marca_de_Equipo_de_ComunicacionAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Marca_de_Equipo_de_Comunicacion.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Marca_de_Equipo_de_Comunicacion.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Marca_de_Equipo_de_Comunicacion.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Marca_de_Equipo_de_Comunicacion.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Marca_de_Equipo_de_Comunicacion.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Marca_de_Equipo_de_Comunicacion.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Equipo))
            {
                switch (filter.Tipo_de_EquipoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_Equipo_de_Comunicacion.Descripcion LIKE '" + filter.AdvanceTipo_de_Equipo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_Equipo_de_Comunicacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Equipo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_Equipo_de_Comunicacion.Descripcion = '" + filter.AdvanceTipo_de_Equipo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_Equipo_de_Comunicacion.Descripcion LIKE '%" + filter.AdvanceTipo_de_Equipo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_EquipoMultiple != null && filter.AdvanceTipo_de_EquipoMultiple.Count() > 0)
            {
                var Tipo_de_EquipoIds = string.Join(",", filter.AdvanceTipo_de_EquipoMultiple);

                where += " AND Marca_de_Equipo_de_Comunicacion.Tipo_de_Equipo In (" + Tipo_de_EquipoIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(short id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);

                Marca_de_Equipo_de_Comunicacion varMarca_de_Equipo_de_Comunicacion = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Marca_de_Equipo_de_ComunicacionModel varMarca_de_Equipo_de_Comunicacion)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Marca_de_Equipo_de_ComunicacionInfo = new Marca_de_Equipo_de_Comunicacion
                    {
                        Clave = varMarca_de_Equipo_de_Comunicacion.Clave
                        ,Descripcion = varMarca_de_Equipo_de_Comunicacion.Descripcion
                        ,Tipo_de_Equipo = varMarca_de_Equipo_de_Comunicacion.Tipo_de_Equipo

                    };

                    result = !IsNew ?
                        _IMarca_de_Equipo_de_ComunicacionApiConsumer.Update(Marca_de_Equipo_de_ComunicacionInfo, null, null).Resource.ToString() :
                         _IMarca_de_Equipo_de_ComunicacionApiConsumer.Insert(Marca_de_Equipo_de_ComunicacionInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Marca_de_Equipo_de_Comunicacion script
        /// </summary>
        /// <param name="oMarca_de_Equipo_de_ComunicacionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Marca_de_Equipo_de_ComunicacionModuleAttributeList)
        {
            for (int i = 0; i < Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strMarca_de_Equipo_de_ComunicacionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Marca_de_Equipo_de_Comunicacion.js")))
            {
                strMarca_de_Equipo_de_ComunicacionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Marca_de_Equipo_de_Comunicacion element attributes
            string userChangeJson = jsSerialize.Serialize(Marca_de_Equipo_de_ComunicacionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMarca_de_Equipo_de_ComunicacionScript.IndexOf("inpuElementArray");
            string splittedString = strMarca_de_Equipo_de_ComunicacionScript.Substring(indexOfArray, strMarca_de_Equipo_de_ComunicacionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMarca_de_Equipo_de_ComunicacionScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strMarca_de_Equipo_de_ComunicacionScript.Substring(indexOfArrayHistory, strMarca_de_Equipo_de_ComunicacionScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strMarca_de_Equipo_de_ComunicacionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMarca_de_Equipo_de_ComunicacionScript.Substring(endIndexOfMainElement + indexOfArray, strMarca_de_Equipo_de_ComunicacionScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Marca_de_Equipo_de_ComunicacionModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Marca_de_Equipo_de_Comunicacion.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Marca_de_Equipo_de_Comunicacion.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Marca_de_Equipo_de_Comunicacion.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult Marca_de_Equipo_de_ComunicacionPropertyBag()
        {
            return PartialView("Marca_de_Equipo_de_ComunicacionPropertyBag", "Marca_de_Equipo_de_Comunicacion");
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
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
		
		
		
		[HttpGet]
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 45520 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Marca_de_Equipo_de_Comunicacion.Clave= " + RecordId;
                            var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir, string where, string order, dynamic columnsVisible)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);
										  
			string[] arrayColumnsVisible = ((string[])columnsVisible)[0].ToString().Split(',');

			 where = HttpUtility.UrlEncode(where);
            if (!_tokenManager.GenerateToken())
                return;

            _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Marca_de_Equipo_de_ComunicacionPropertyMapper());
			
			 if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Marca_de_Equipo_de_ComunicacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Marca_de_Equipo_de_ComunicacionPropertyMapper oMarca_de_Equipo_de_ComunicacionPropertyMapper = new Marca_de_Equipo_de_ComunicacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMarca_de_Equipo_de_ComunicacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Marca_de_Equipo_de_Comunicacions == null)
                result.Marca_de_Equipo_de_Comunicacions = new List<Marca_de_Equipo_de_Comunicacion>();

            var data = result.Marca_de_Equipo_de_Comunicacions.Select(m => new Marca_de_Equipo_de_ComunicacionGridModel
            {
                Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(45520, arrayColumnsVisible), "Marca_de_Equipo_de_ComunicacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(45520, arrayColumnsVisible), "Marca_de_Equipo_de_ComunicacionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(45520, arrayColumnsVisible), "Marca_de_Equipo_de_ComunicacionList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir,string where, string order)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

			where = HttpUtility.UrlEncode(where);
										   
            if (!_tokenManager.GenerateToken())
                return null;

            _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Marca_de_Equipo_de_ComunicacionPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Marca_de_Equipo_de_ComunicacionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Marca_de_Equipo_de_ComunicacionPropertyMapper oMarca_de_Equipo_de_ComunicacionPropertyMapper = new Marca_de_Equipo_de_ComunicacionPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oMarca_de_Equipo_de_ComunicacionPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Marca_de_Equipo_de_Comunicacions == null)
                result.Marca_de_Equipo_de_Comunicacions = new List<Marca_de_Equipo_de_Comunicacion>();

            var data = result.Marca_de_Equipo_de_Comunicacions.Select(m => new Marca_de_Equipo_de_ComunicacionGridModel
            {
                Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Marca_de_Equipo_de_Comunicacion_Datos_GeneralesModel varMarca_de_Equipo_de_Comunicacion)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Marca_de_Equipo_de_Comunicacion_Datos_GeneralesInfo = new Marca_de_Equipo_de_Comunicacion_Datos_Generales
                {
                    Clave = varMarca_de_Equipo_de_Comunicacion.Clave
                                            ,Descripcion = varMarca_de_Equipo_de_Comunicacion.Descripcion
                        ,Tipo_de_Equipo = varMarca_de_Equipo_de_Comunicacion.Tipo_de_Equipo
                    
                };

                result = _IMarca_de_Equipo_de_ComunicacionApiConsumer.Update_Datos_Generales(Marca_de_Equipo_de_Comunicacion_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarca_de_Equipo_de_ComunicacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IMarca_de_Equipo_de_ComunicacionApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Marca_de_Equipo_de_Comunicacion_Datos_GeneralesModel
                {
                    Clave = m.Clave
			,Descripcion = m.Descripcion
                        ,Tipo_de_Equipo = m.Tipo_de_Equipo
                        ,Tipo_de_EquipoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Equipo_Tipo_de_Equipo_de_Comunicacion.Descripcion

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

