﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_de_Guardado_de_Movimiento;
using Spartane.Core.Domain.Registro_de_Movimiento;
using Spartane.Core.Domain.Detalle_Datos_Adicionales_Movimiento;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_de_Guardado_de_Movimiento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Guardado_de_Movimiento;
using Spartane.Web.Areas.WebApiConsumer.Registro_de_Movimiento;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Datos_Adicionales_Movimiento;

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
    public class Detalle_de_Guardado_de_MovimientoController : Controller
    {
        #region "variable declaration"

        private IDetalle_de_Guardado_de_MovimientoService service = null;
        private IDetalle_de_Guardado_de_MovimientoApiConsumer _IDetalle_de_Guardado_de_MovimientoApiConsumer;
        private IRegistro_de_MovimientoApiConsumer _IRegistro_de_MovimientoApiConsumer;
        private IDetalle_Datos_Adicionales_MovimientoApiConsumer _IDetalle_Datos_Adicionales_MovimientoApiConsumer;

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

        
        public Detalle_de_Guardado_de_MovimientoController(IDetalle_de_Guardado_de_MovimientoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_de_Guardado_de_MovimientoApiConsumer Detalle_de_Guardado_de_MovimientoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IRegistro_de_MovimientoApiConsumer Registro_de_MovimientoApiConsumer , IDetalle_Datos_Adicionales_MovimientoApiConsumer Detalle_Datos_Adicionales_MovimientoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_de_Guardado_de_MovimientoApiConsumer = Detalle_de_Guardado_de_MovimientoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IRegistro_de_MovimientoApiConsumer = Registro_de_MovimientoApiConsumer;
            this._IDetalle_Datos_Adicionales_MovimientoApiConsumer = Detalle_Datos_Adicionales_MovimientoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_de_Guardado_de_Movimiento
        [ObjectAuth(ObjectId = (ModuleObjectId)45640, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45640, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Detalle_de_Guardado_de_Movimiento/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)45640, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45640, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varDetalle_de_Guardado_de_Movimiento = new Detalle_de_Guardado_de_MovimientoModel();
			varDetalle_de_Guardado_de_Movimiento.Clave = Id;
			
            ViewBag.ObjectId = "45640";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_de_Guardado_de_MovimientosData = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Guardado_de_Movimiento.Clave=" + Id, "").Resource.Detalle_de_Guardado_de_Movimientos;
				
				if (Detalle_de_Guardado_de_MovimientosData != null && Detalle_de_Guardado_de_MovimientosData.Count > 0)
                {
					var Detalle_de_Guardado_de_MovimientoData = Detalle_de_Guardado_de_MovimientosData.First();
					varDetalle_de_Guardado_de_Movimiento= new Detalle_de_Guardado_de_MovimientoModel
					{
						Clave  = Detalle_de_Guardado_de_MovimientoData.Clave 
	                    ,Registro_de_Movimiento = Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento
                    ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento), "Registro_de_Movimiento") ??  (string)Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                    ,Campo = Detalle_de_Guardado_de_MovimientoData.Campo
                    ,CampoDato = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Guardado_de_MovimientoData.Campo), "Detalle_Datos_Adicionales_Movimiento") ??  (string)Detalle_de_Guardado_de_MovimientoData.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
                    ,Etiqueta = Detalle_de_Guardado_de_MovimientoData.Etiqueta
                    ,Valor = Detalle_de_Guardado_de_MovimientoData.Valor

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



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

				
            return View(varDetalle_de_Guardado_de_Movimiento);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_de_Guardado_de_Movimiento(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45640);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_de_Guardado_de_MovimientoModel varDetalle_de_Guardado_de_Movimiento= new Detalle_de_Guardado_de_MovimientoModel();


            if (id.ToString() != "0")
            {
                var Detalle_de_Guardado_de_MovimientosData = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Guardado_de_Movimiento.Clave=" + id, "").Resource.Detalle_de_Guardado_de_Movimientos;
				
				if (Detalle_de_Guardado_de_MovimientosData != null && Detalle_de_Guardado_de_MovimientosData.Count > 0)
                {
					var Detalle_de_Guardado_de_MovimientoData = Detalle_de_Guardado_de_MovimientosData.First();
					varDetalle_de_Guardado_de_Movimiento= new Detalle_de_Guardado_de_MovimientoModel
					{
						Clave  = Detalle_de_Guardado_de_MovimientoData.Clave 
	                    ,Registro_de_Movimiento = Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento
                    ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento), "Registro_de_Movimiento") ??  (string)Detalle_de_Guardado_de_MovimientoData.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                    ,Campo = Detalle_de_Guardado_de_MovimientoData.Campo
                    ,CampoDato = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_Guardado_de_MovimientoData.Campo), "Detalle_Datos_Adicionales_Movimiento") ??  (string)Detalle_de_Guardado_de_MovimientoData.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
                    ,Etiqueta = Detalle_de_Guardado_de_MovimientoData.Etiqueta
                    ,Valor = Detalle_de_Guardado_de_MovimientoData.Valor

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddDetalle_de_Guardado_de_Movimiento", varDetalle_de_Guardado_de_Movimiento);
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
        public ActionResult GetRegistro_de_MovimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_de_MovimientoApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Informacion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Registro_de_Movimiento", "Informacion")?? m.Informacion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetDetalle_Datos_Adicionales_MovimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Datos_Adicionales_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Datos_Adicionales_MovimientoApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Dato).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Detalle_Datos_Adicionales_Movimiento", "Dato")?? m.Dato,
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
        public ActionResult ShowAdvanceFilter(Detalle_de_Guardado_de_MovimientoAdvanceSearchModel model, int idFilter = -1)
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



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Detalle_de_Guardado_de_MovimientoAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Detalle_de_Guardado_de_MovimientoAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Detalle_de_Guardado_de_MovimientoAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_Guardado_de_MovimientoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Guardado_de_Movimientos == null)
                result.Detalle_de_Guardado_de_Movimientos = new List<Detalle_de_Guardado_de_Movimiento>();

            return Json(new
            {
                data = result.Detalle_de_Guardado_de_Movimientos.Select(m => new Detalle_de_Guardado_de_MovimientoGridModel
                    {
                    Clave = m.Clave
                        ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(m.Registro_de_Movimiento_Registro_de_Movimiento.Clave.ToString(), "Registro_de_Movimiento") ?? (string)m.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                        ,CampoDato = CultureHelper.GetTraduction(m.Campo_Detalle_Datos_Adicionales_Movimiento.Clave.ToString(), "Detalle_Datos_Adicionales_Movimiento") ?? (string)m.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
			,Etiqueta = m.Etiqueta
			,Valor = m.Valor

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetDetalle_de_Guardado_de_MovimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Detalle_de_Guardado_de_Movimiento", m.),
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
        /// Get List of Detalle_de_Guardado_de_Movimiento from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Detalle_de_Guardado_de_Movimiento Entity</returns>
        public ActionResult GetDetalle_de_Guardado_de_MovimientoList(UrlParametersModel param)
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
            _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Detalle_de_Guardado_de_MovimientoPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Detalle_de_Guardado_de_MovimientoAdvanceSearchModel))
                {
					var advanceFilter =
                    (Detalle_de_Guardado_de_MovimientoAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Detalle_de_Guardado_de_MovimientoPropertyMapper oDetalle_de_Guardado_de_MovimientoPropertyMapper = new Detalle_de_Guardado_de_MovimientoPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oDetalle_de_Guardado_de_MovimientoPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Guardado_de_Movimientos == null)
                result.Detalle_de_Guardado_de_Movimientos = new List<Detalle_de_Guardado_de_Movimiento>();

            return Json(new
            {
                aaData = result.Detalle_de_Guardado_de_Movimientos.Select(m => new Detalle_de_Guardado_de_MovimientoGridModel
            {
                    Clave = m.Clave
                        ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(m.Registro_de_Movimiento_Registro_de_Movimiento.Clave.ToString(), "Registro_de_Movimiento") ?? (string)m.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                        ,CampoDato = CultureHelper.GetTraduction(m.Campo_Detalle_Datos_Adicionales_Movimiento.Clave.ToString(), "Detalle_Datos_Adicionales_Movimiento") ?? (string)m.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
			,Etiqueta = m.Etiqueta
			,Valor = m.Valor

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_de_Guardado_de_Movimiento_Registro_de_Movimiento_Registro_de_Movimiento(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Registro_de_Movimiento.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Registro_de_Movimiento.Informacion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IRegistro_de_MovimientoApiConsumer.ListaSelAll(1, 20,elWhere , " Registro_de_Movimiento.Informacion ASC ").Resource;
               
                foreach (var item in result.Registro_de_Movimientos)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Registro_de_Movimiento", "Informacion");
                    item.Informacion =trans ??item.Informacion;
                }
                return Json(result.Registro_de_Movimientos.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDetalle_de_Guardado_de_Movimiento_Campo_Detalle_Datos_Adicionales_Movimiento(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Datos_Adicionales_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Detalle_Datos_Adicionales_Movimiento.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Detalle_Datos_Adicionales_Movimiento.Dato as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IDetalle_Datos_Adicionales_MovimientoApiConsumer.ListaSelAll(1, 20,elWhere , " Detalle_Datos_Adicionales_Movimiento.Dato ASC ").Resource;
               
                foreach (var item in result.Detalle_Datos_Adicionales_Movimientos)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Detalle_Datos_Adicionales_Movimiento", "Dato");
                    item.Dato =trans ??item.Dato;
                }
                return Json(result.Detalle_Datos_Adicionales_Movimientos.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        [NonAction]
        public string GetAdvanceFilter(Detalle_de_Guardado_de_MovimientoAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Detalle_de_Guardado_de_Movimiento.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Detalle_de_Guardado_de_Movimiento.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRegistro_de_Movimiento))
            {
                switch (filter.Registro_de_MovimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Movimiento.Informacion LIKE '" + filter.AdvanceRegistro_de_Movimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Movimiento.Informacion LIKE '%" + filter.AdvanceRegistro_de_Movimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Movimiento.Informacion = '" + filter.AdvanceRegistro_de_Movimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Movimiento.Informacion LIKE '%" + filter.AdvanceRegistro_de_Movimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRegistro_de_MovimientoMultiple != null && filter.AdvanceRegistro_de_MovimientoMultiple.Count() > 0)
            {
                var Registro_de_MovimientoIds = string.Join(",", filter.AdvanceRegistro_de_MovimientoMultiple);

                where += " AND Detalle_de_Guardado_de_Movimiento.Registro_de_Movimiento In (" + Registro_de_MovimientoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCampo))
            {
                switch (filter.CampoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_Datos_Adicionales_Movimiento.Dato LIKE '" + filter.AdvanceCampo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_Datos_Adicionales_Movimiento.Dato LIKE '%" + filter.AdvanceCampo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_Datos_Adicionales_Movimiento.Dato = '" + filter.AdvanceCampo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_Datos_Adicionales_Movimiento.Dato LIKE '%" + filter.AdvanceCampo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCampoMultiple != null && filter.AdvanceCampoMultiple.Count() > 0)
            {
                var CampoIds = string.Join(",", filter.AdvanceCampoMultiple);

                where += " AND Detalle_de_Guardado_de_Movimiento.Campo In (" + CampoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Etiqueta))
            {
                switch (filter.EtiquetaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Etiqueta LIKE '" + filter.Etiqueta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Etiqueta LIKE '%" + filter.Etiqueta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Etiqueta = '" + filter.Etiqueta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Etiqueta LIKE '%" + filter.Etiqueta + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Valor))
            {
                switch (filter.ValorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Valor LIKE '" + filter.Valor + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Valor LIKE '%" + filter.Valor + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Valor = '" + filter.Valor + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_de_Guardado_de_Movimiento.Valor LIKE '%" + filter.Valor + "%'";
                        break;
                }
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
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_de_Guardado_de_Movimiento varDetalle_de_Guardado_de_Movimiento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_de_Guardado_de_MovimientoModel varDetalle_de_Guardado_de_Movimiento)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_de_Guardado_de_MovimientoInfo = new Detalle_de_Guardado_de_Movimiento
                    {
                        Clave = varDetalle_de_Guardado_de_Movimiento.Clave
                        ,Registro_de_Movimiento = varDetalle_de_Guardado_de_Movimiento.Registro_de_Movimiento
                        ,Campo = varDetalle_de_Guardado_de_Movimiento.Campo
                        ,Etiqueta = varDetalle_de_Guardado_de_Movimiento.Etiqueta
                        ,Valor = varDetalle_de_Guardado_de_Movimiento.Valor

                    };

                    result = !IsNew ?
                        _IDetalle_de_Guardado_de_MovimientoApiConsumer.Update(Detalle_de_Guardado_de_MovimientoInfo, null, null).Resource.ToString() :
                         _IDetalle_de_Guardado_de_MovimientoApiConsumer.Insert(Detalle_de_Guardado_de_MovimientoInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Detalle_de_Guardado_de_Movimiento script
        /// </summary>
        /// <param name="oDetalle_de_Guardado_de_MovimientoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Detalle_de_Guardado_de_MovimientoModuleAttributeList)
        {
            for (int i = 0; i < Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strDetalle_de_Guardado_de_MovimientoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Guardado_de_Movimiento.js")))
            {
                strDetalle_de_Guardado_de_MovimientoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_de_Guardado_de_Movimiento element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_de_Guardado_de_MovimientoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_de_Guardado_de_MovimientoScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_de_Guardado_de_MovimientoScript.Substring(indexOfArray, strDetalle_de_Guardado_de_MovimientoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_de_Guardado_de_MovimientoScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strDetalle_de_Guardado_de_MovimientoScript.Substring(indexOfArrayHistory, strDetalle_de_Guardado_de_MovimientoScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strDetalle_de_Guardado_de_MovimientoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_de_Guardado_de_MovimientoScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_de_Guardado_de_MovimientoScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Detalle_de_Guardado_de_MovimientoModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_de_Guardado_de_Movimiento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_de_Guardado_de_Movimiento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Guardado_de_Movimiento.js")))
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
        public ActionResult Detalle_de_Guardado_de_MovimientoPropertyBag()
        {
            return PartialView("Detalle_de_Guardado_de_MovimientoPropertyBag", "Detalle_de_Guardado_de_Movimiento");
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
                var whereClauseFormat = "Object = 45640 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Detalle_de_Guardado_de_Movimiento.Clave= " + RecordId;
                            var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Detalle_de_Guardado_de_MovimientoPropertyMapper());
			
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
                    (Detalle_de_Guardado_de_MovimientoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Detalle_de_Guardado_de_MovimientoPropertyMapper oDetalle_de_Guardado_de_MovimientoPropertyMapper = new Detalle_de_Guardado_de_MovimientoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDetalle_de_Guardado_de_MovimientoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Guardado_de_Movimientos == null)
                result.Detalle_de_Guardado_de_Movimientos = new List<Detalle_de_Guardado_de_Movimiento>();

            var data = result.Detalle_de_Guardado_de_Movimientos.Select(m => new Detalle_de_Guardado_de_MovimientoGridModel
            {
                Clave = m.Clave
                        ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(m.Registro_de_Movimiento_Registro_de_Movimiento.Clave.ToString(), "Registro_de_Movimiento") ?? (string)m.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                        ,CampoDato = CultureHelper.GetTraduction(m.Campo_Detalle_Datos_Adicionales_Movimiento.Clave.ToString(), "Detalle_Datos_Adicionales_Movimiento") ?? (string)m.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
			,Etiqueta = m.Etiqueta
			,Valor = m.Valor

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(45640, arrayColumnsVisible), "Detalle_de_Guardado_de_MovimientoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(45640, arrayColumnsVisible), "Detalle_de_Guardado_de_MovimientoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(45640, arrayColumnsVisible), "Detalle_de_Guardado_de_MovimientoList_" + DateTime.Now.ToString());
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

            _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Detalle_de_Guardado_de_MovimientoPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Detalle_de_Guardado_de_MovimientoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Detalle_de_Guardado_de_MovimientoPropertyMapper oDetalle_de_Guardado_de_MovimientoPropertyMapper = new Detalle_de_Guardado_de_MovimientoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oDetalle_de_Guardado_de_MovimientoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Guardado_de_Movimientos == null)
                result.Detalle_de_Guardado_de_Movimientos = new List<Detalle_de_Guardado_de_Movimiento>();

            var data = result.Detalle_de_Guardado_de_Movimientos.Select(m => new Detalle_de_Guardado_de_MovimientoGridModel
            {
                Clave = m.Clave
                        ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(m.Registro_de_Movimiento_Registro_de_Movimiento.Clave.ToString(), "Registro_de_Movimiento") ?? (string)m.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                        ,CampoDato = CultureHelper.GetTraduction(m.Campo_Detalle_Datos_Adicionales_Movimiento.Clave.ToString(), "Detalle_Datos_Adicionales_Movimiento") ?? (string)m.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
			,Etiqueta = m.Etiqueta
			,Valor = m.Valor

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
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Detalle_de_Guardado_de_Movimiento_Datos_GeneralesModel varDetalle_de_Guardado_de_Movimiento)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Detalle_de_Guardado_de_Movimiento_Datos_GeneralesInfo = new Detalle_de_Guardado_de_Movimiento_Datos_Generales
                {
                    Clave = varDetalle_de_Guardado_de_Movimiento.Clave
                                            ,Registro_de_Movimiento = varDetalle_de_Guardado_de_Movimiento.Registro_de_Movimiento
                        ,Campo = varDetalle_de_Guardado_de_Movimiento.Campo
                        ,Etiqueta = varDetalle_de_Guardado_de_Movimiento.Etiqueta
                        ,Valor = varDetalle_de_Guardado_de_Movimiento.Valor
                    
                };

                result = _IDetalle_de_Guardado_de_MovimientoApiConsumer.Update_Datos_Generales(Detalle_de_Guardado_de_Movimiento_Datos_GeneralesInfo).Resource.ToString();
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
                _IDetalle_de_Guardado_de_MovimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IDetalle_de_Guardado_de_MovimientoApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Detalle_de_Guardado_de_Movimiento_Datos_GeneralesModel
                {
                    Clave = m.Clave
                        ,Registro_de_Movimiento = m.Registro_de_Movimiento
                        ,Registro_de_MovimientoInformacion = CultureHelper.GetTraduction(m.Registro_de_Movimiento_Registro_de_Movimiento.Clave.ToString(), "Registro_de_Movimiento") ?? (string)m.Registro_de_Movimiento_Registro_de_Movimiento.Informacion
                        ,Campo = m.Campo
                        ,CampoDato = CultureHelper.GetTraduction(m.Campo_Detalle_Datos_Adicionales_Movimiento.Clave.ToString(), "Detalle_Datos_Adicionales_Movimiento") ?? (string)m.Campo_Detalle_Datos_Adicionales_Movimiento.Dato
			,Etiqueta = m.Etiqueta
			,Valor = m.Valor

                    
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

