﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Encuesta;
using Spartane.Core.Domain.Modulo_Encuesta;
using Spartane.Core.Domain.Tipo_Encuesta;
using Spartane.Core.Domain.Catalogo_Numero_de_Preguntas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Encuesta;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Encuesta;
using Spartane.Web.Areas.WebApiConsumer.Modulo_Encuesta;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Encuesta;
using Spartane.Web.Areas.WebApiConsumer.Catalogo_Numero_de_Preguntas;

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
    public class EncuestaController : Controller
    {
        #region "variable declaration"

        private IEncuestaService service = null;
        private IEncuestaApiConsumer _IEncuestaApiConsumer;
        private IModulo_EncuestaApiConsumer _IModulo_EncuestaApiConsumer;
        private ITipo_EncuestaApiConsumer _ITipo_EncuestaApiConsumer;
        private ICatalogo_Numero_de_PreguntasApiConsumer _ICatalogo_Numero_de_PreguntasApiConsumer;

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

        
        public EncuestaController(IEncuestaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IEncuestaApiConsumer EncuestaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IModulo_EncuestaApiConsumer Modulo_EncuestaApiConsumer , ITipo_EncuestaApiConsumer Tipo_EncuestaApiConsumer , ICatalogo_Numero_de_PreguntasApiConsumer Catalogo_Numero_de_PreguntasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IEncuestaApiConsumer = EncuestaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IModulo_EncuestaApiConsumer = Modulo_EncuestaApiConsumer;
            this._ITipo_EncuestaApiConsumer = Tipo_EncuestaApiConsumer;
            this._ICatalogo_Numero_de_PreguntasApiConsumer = Catalogo_Numero_de_PreguntasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Encuesta
        [ObjectAuth(ObjectId = (ModuleObjectId)45110, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45110, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Encuesta/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)45110, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45110, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varEncuesta = new EncuestaModel();
			varEncuesta.Clave = Id;
			
            ViewBag.ObjectId = "45110";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var EncuestasData = _IEncuestaApiConsumer.ListaSelAll(0, 1000, "Encuesta.Clave=" + Id, "").Resource.Encuestas;
				
				if (EncuestasData != null && EncuestasData.Count > 0)
                {
					var EncuestaData = EncuestasData.First();
					varEncuesta= new EncuestaModel
					{
						Clave  = EncuestaData.Clave 
	                    ,Modulo = EncuestaData.Modulo
                    ,ModuloDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Modulo), "Modulo_Encuesta") ??  (string)EncuestaData.Modulo_Modulo_Encuesta.Descripcion
                    ,Tipo_Encuesta = EncuestaData.Tipo_Encuesta
                    ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Tipo_Encuesta), "Tipo_Encuesta") ??  (string)EncuestaData.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                    ,Numero_de_Preguntas = EncuestaData.Numero_de_Preguntas
                    ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Numero_de_Preguntas), "Catalogo_Numero_de_Preguntas") ??  (string)EncuestaData.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
                    ,Pregunta_1 = EncuestaData.Pregunta_1
                    ,Pregunta_2 = EncuestaData.Pregunta_2
                    ,Pregunta_3 = EncuestaData.Pregunta_3
                    ,Pregunta_4 = EncuestaData.Pregunta_4
                    ,Pregunta_5 = EncuestaData.Pregunta_5

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IModulo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Modulo_Encuestas_Modulo = _IModulo_EncuestaApiConsumer.SelAll(true);
            if (Modulo_Encuestas_Modulo != null && Modulo_Encuestas_Modulo.Resource != null)
                ViewBag.Modulo_Encuestas_Modulo = Modulo_Encuestas_Modulo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Modulo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Encuestas_Tipo_Encuesta = _ITipo_EncuestaApiConsumer.SelAll(true);
            if (Tipo_Encuestas_Tipo_Encuesta != null && Tipo_Encuestas_Tipo_Encuesta.Resource != null)
                ViewBag.Tipo_Encuestas_Tipo_Encuesta = Tipo_Encuestas_Tipo_Encuesta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICatalogo_Numero_de_PreguntasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = _ICatalogo_Numero_de_PreguntasApiConsumer.SelAll(true);
            if (Catalogo_Numero_de_Preguntass_Numero_de_Preguntas != null && Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource != null)
                ViewBag.Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Catalogo_Numero_de_Preguntas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varEncuesta);
        }
		
	[HttpGet]
        public ActionResult AddEncuesta(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45110);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
			EncuestaModel varEncuesta= new EncuestaModel();


            if (id.ToString() != "0")
            {
                var EncuestasData = _IEncuestaApiConsumer.ListaSelAll(0, 1000, "Encuesta.Clave=" + id, "").Resource.Encuestas;
				
				if (EncuestasData != null && EncuestasData.Count > 0)
                {
					var EncuestaData = EncuestasData.First();
					varEncuesta= new EncuestaModel
					{
						Clave  = EncuestaData.Clave 
	                    ,Modulo = EncuestaData.Modulo
                    ,ModuloDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Modulo), "Modulo_Encuesta") ??  (string)EncuestaData.Modulo_Modulo_Encuesta.Descripcion
                    ,Tipo_Encuesta = EncuestaData.Tipo_Encuesta
                    ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Tipo_Encuesta), "Tipo_Encuesta") ??  (string)EncuestaData.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                    ,Numero_de_Preguntas = EncuestaData.Numero_de_Preguntas
                    ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(Convert.ToString(EncuestaData.Numero_de_Preguntas), "Catalogo_Numero_de_Preguntas") ??  (string)EncuestaData.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
                    ,Pregunta_1 = EncuestaData.Pregunta_1
                    ,Pregunta_2 = EncuestaData.Pregunta_2
                    ,Pregunta_3 = EncuestaData.Pregunta_3
                    ,Pregunta_4 = EncuestaData.Pregunta_4
                    ,Pregunta_5 = EncuestaData.Pregunta_5

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IModulo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Modulo_Encuestas_Modulo = _IModulo_EncuestaApiConsumer.SelAll(true);
            if (Modulo_Encuestas_Modulo != null && Modulo_Encuestas_Modulo.Resource != null)
                ViewBag.Modulo_Encuestas_Modulo = Modulo_Encuestas_Modulo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Modulo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Encuestas_Tipo_Encuesta = _ITipo_EncuestaApiConsumer.SelAll(true);
            if (Tipo_Encuestas_Tipo_Encuesta != null && Tipo_Encuestas_Tipo_Encuesta.Resource != null)
                ViewBag.Tipo_Encuestas_Tipo_Encuesta = Tipo_Encuestas_Tipo_Encuesta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICatalogo_Numero_de_PreguntasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = _ICatalogo_Numero_de_PreguntasApiConsumer.SelAll(true);
            if (Catalogo_Numero_de_Preguntass_Numero_de_Preguntas != null && Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource != null)
                ViewBag.Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Catalogo_Numero_de_Preguntas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddEncuesta", varEncuesta);
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
        public ActionResult GetModulo_EncuestaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IModulo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IModulo_EncuestaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Modulo_Encuesta", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTipo_EncuestaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_EncuestaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Encuesta", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetCatalogo_Numero_de_PreguntasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICatalogo_Numero_de_PreguntasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICatalogo_Numero_de_PreguntasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Catalogo_Numero_de_Preguntas", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(EncuestaAdvanceSearchModel model, int idFilter = -1)
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

            _IModulo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Modulo_Encuestas_Modulo = _IModulo_EncuestaApiConsumer.SelAll(true);
            if (Modulo_Encuestas_Modulo != null && Modulo_Encuestas_Modulo.Resource != null)
                ViewBag.Modulo_Encuestas_Modulo = Modulo_Encuestas_Modulo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Modulo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Encuestas_Tipo_Encuesta = _ITipo_EncuestaApiConsumer.SelAll(true);
            if (Tipo_Encuestas_Tipo_Encuesta != null && Tipo_Encuestas_Tipo_Encuesta.Resource != null)
                ViewBag.Tipo_Encuestas_Tipo_Encuesta = Tipo_Encuestas_Tipo_Encuesta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICatalogo_Numero_de_PreguntasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = _ICatalogo_Numero_de_PreguntasApiConsumer.SelAll(true);
            if (Catalogo_Numero_de_Preguntass_Numero_de_Preguntas != null && Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource != null)
                ViewBag.Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Catalogo_Numero_de_Preguntas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IModulo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Modulo_Encuestas_Modulo = _IModulo_EncuestaApiConsumer.SelAll(true);
            if (Modulo_Encuestas_Modulo != null && Modulo_Encuestas_Modulo.Resource != null)
                ViewBag.Modulo_Encuestas_Modulo = Modulo_Encuestas_Modulo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Modulo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITipo_EncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Encuestas_Tipo_Encuesta = _ITipo_EncuestaApiConsumer.SelAll(true);
            if (Tipo_Encuestas_Tipo_Encuesta != null && Tipo_Encuestas_Tipo_Encuesta.Resource != null)
                ViewBag.Tipo_Encuestas_Tipo_Encuesta = Tipo_Encuestas_Tipo_Encuesta.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Encuesta", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICatalogo_Numero_de_PreguntasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = _ICatalogo_Numero_de_PreguntasApiConsumer.SelAll(true);
            if (Catalogo_Numero_de_Preguntass_Numero_de_Preguntas != null && Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource != null)
                ViewBag.Catalogo_Numero_de_Preguntass_Numero_de_Preguntas = Catalogo_Numero_de_Preguntass_Numero_de_Preguntas.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Catalogo_Numero_de_Preguntas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new EncuestaAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (EncuestaAdvanceSearchModel)(Session["AdvanceSearch"] ?? new EncuestaAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new EncuestaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IEncuestaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Encuestas == null)
                result.Encuestas = new List<Encuesta>();

            return Json(new
            {
                data = result.Encuestas.Select(m => new EncuestaGridModel
                    {
                    Clave = m.Clave
                        ,ModuloDescripcion = CultureHelper.GetTraduction(m.Modulo_Modulo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Modulo_Modulo_Encuesta.Descripcion
                        ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(m.Tipo_Encuesta_Tipo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                        ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Clave.ToString(), "Descripcion") ?? (string)m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
			,Pregunta_1 = m.Pregunta_1
			,Pregunta_2 = m.Pregunta_2
			,Pregunta_3 = m.Pregunta_3
			,Pregunta_4 = m.Pregunta_4
			,Pregunta_5 = m.Pregunta_5

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetEncuestaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEncuestaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Encuesta", m.),
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
        /// Get List of Encuesta from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Encuesta Entity</returns>
        public ActionResult GetEncuestaList(UrlParametersModel param)
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
            _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new EncuestaPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(EncuestaAdvanceSearchModel))
                {
					var advanceFilter =
                    (EncuestaAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            EncuestaPropertyMapper oEncuestaPropertyMapper = new EncuestaPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oEncuestaPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IEncuestaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Encuestas == null)
                result.Encuestas = new List<Encuesta>();

            return Json(new
            {
                aaData = result.Encuestas.Select(m => new EncuestaGridModel
            {
                    Clave = m.Clave
                        ,ModuloDescripcion = CultureHelper.GetTraduction(m.Modulo_Modulo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Modulo_Modulo_Encuesta.Descripcion
                        ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(m.Tipo_Encuesta_Tipo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                        ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Clave.ToString(), "Descripcion") ?? (string)m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
			,Pregunta_1 = m.Pregunta_1
			,Pregunta_2 = m.Pregunta_2
			,Pregunta_3 = m.Pregunta_3
			,Pregunta_4 = m.Pregunta_4
			,Pregunta_5 = m.Pregunta_5

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(EncuestaAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Encuesta.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Encuesta.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceModulo))
            {
                switch (filter.ModuloFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Modulo_Encuesta.Descripcion LIKE '" + filter.AdvanceModulo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Modulo_Encuesta.Descripcion LIKE '%" + filter.AdvanceModulo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Modulo_Encuesta.Descripcion = '" + filter.AdvanceModulo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Modulo_Encuesta.Descripcion LIKE '%" + filter.AdvanceModulo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceModuloMultiple != null && filter.AdvanceModuloMultiple.Count() > 0)
            {
                var ModuloIds = string.Join(",", filter.AdvanceModuloMultiple);

                where += " AND Encuesta.Modulo In (" + ModuloIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_Encuesta))
            {
                switch (filter.Tipo_EncuestaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_Encuesta.Descripcion LIKE '" + filter.AdvanceTipo_Encuesta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_Encuesta.Descripcion LIKE '%" + filter.AdvanceTipo_Encuesta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_Encuesta.Descripcion = '" + filter.AdvanceTipo_Encuesta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_Encuesta.Descripcion LIKE '%" + filter.AdvanceTipo_Encuesta + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_EncuestaMultiple != null && filter.AdvanceTipo_EncuestaMultiple.Count() > 0)
            {
                var Tipo_EncuestaIds = string.Join(",", filter.AdvanceTipo_EncuestaMultiple);

                where += " AND Encuesta.Tipo_Encuesta In (" + Tipo_EncuestaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceNumero_de_Preguntas))
            {
                switch (filter.Numero_de_PreguntasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Catalogo_Numero_de_Preguntas.Descripcion LIKE '" + filter.AdvanceNumero_de_Preguntas + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Catalogo_Numero_de_Preguntas.Descripcion LIKE '%" + filter.AdvanceNumero_de_Preguntas + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Catalogo_Numero_de_Preguntas.Descripcion = '" + filter.AdvanceNumero_de_Preguntas + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Catalogo_Numero_de_Preguntas.Descripcion LIKE '%" + filter.AdvanceNumero_de_Preguntas + "%'";
                        break;
                }
            }
            else if (filter.AdvanceNumero_de_PreguntasMultiple != null && filter.AdvanceNumero_de_PreguntasMultiple.Count() > 0)
            {
                var Numero_de_PreguntasIds = string.Join(",", filter.AdvanceNumero_de_PreguntasMultiple);

                where += " AND Encuesta.Numero_de_Preguntas In (" + Numero_de_PreguntasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Pregunta_1))
            {
                switch (filter.Pregunta_1Filter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Encuesta.Pregunta_1 LIKE '" + filter.Pregunta_1 + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Encuesta.Pregunta_1 LIKE '%" + filter.Pregunta_1 + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Encuesta.Pregunta_1 = '" + filter.Pregunta_1 + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Encuesta.Pregunta_1 LIKE '%" + filter.Pregunta_1 + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Pregunta_2))
            {
                switch (filter.Pregunta_2Filter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Encuesta.Pregunta_2 LIKE '" + filter.Pregunta_2 + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Encuesta.Pregunta_2 LIKE '%" + filter.Pregunta_2 + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Encuesta.Pregunta_2 = '" + filter.Pregunta_2 + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Encuesta.Pregunta_2 LIKE '%" + filter.Pregunta_2 + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Pregunta_3))
            {
                switch (filter.Pregunta_3Filter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Encuesta.Pregunta_3 LIKE '" + filter.Pregunta_3 + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Encuesta.Pregunta_3 LIKE '%" + filter.Pregunta_3 + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Encuesta.Pregunta_3 = '" + filter.Pregunta_3 + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Encuesta.Pregunta_3 LIKE '%" + filter.Pregunta_3 + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Pregunta_4))
            {
                switch (filter.Pregunta_4Filter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Encuesta.Pregunta_4 LIKE '" + filter.Pregunta_4 + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Encuesta.Pregunta_4 LIKE '%" + filter.Pregunta_4 + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Encuesta.Pregunta_4 = '" + filter.Pregunta_4 + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Encuesta.Pregunta_4 LIKE '%" + filter.Pregunta_4 + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Pregunta_5))
            {
                switch (filter.Pregunta_5Filter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Encuesta.Pregunta_5 LIKE '" + filter.Pregunta_5 + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Encuesta.Pregunta_5 LIKE '%" + filter.Pregunta_5 + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Encuesta.Pregunta_5 = '" + filter.Pregunta_5 + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Encuesta.Pregunta_5 LIKE '%" + filter.Pregunta_5 + "%'";
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
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Encuesta varEncuesta = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IEncuestaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, EncuestaModel varEncuesta)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var EncuestaInfo = new Encuesta
                    {
                        Clave = varEncuesta.Clave
                        ,Modulo = varEncuesta.Modulo
                        ,Tipo_Encuesta = varEncuesta.Tipo_Encuesta
                        ,Numero_de_Preguntas = varEncuesta.Numero_de_Preguntas
                        ,Pregunta_1 = varEncuesta.Pregunta_1
                        ,Pregunta_2 = varEncuesta.Pregunta_2
                        ,Pregunta_3 = varEncuesta.Pregunta_3
                        ,Pregunta_4 = varEncuesta.Pregunta_4
                        ,Pregunta_5 = varEncuesta.Pregunta_5

                    };

                    result = !IsNew ?
                        _IEncuestaApiConsumer.Update(EncuestaInfo, null, null).Resource.ToString() :
                         _IEncuestaApiConsumer.Insert(EncuestaInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Encuesta script
        /// </summary>
        /// <param name="oEncuestaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew EncuestaModuleAttributeList)
        {
            for (int i = 0; i < EncuestaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(EncuestaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    EncuestaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(EncuestaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    EncuestaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (EncuestaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < EncuestaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < EncuestaModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(EncuestaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							EncuestaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(EncuestaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							EncuestaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strEncuestaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Encuesta.js")))
            {
                strEncuestaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Encuesta element attributes
            string userChangeJson = jsSerialize.Serialize(EncuestaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strEncuestaScript.IndexOf("inpuElementArray");
            string splittedString = strEncuestaScript.Substring(indexOfArray, strEncuestaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(EncuestaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (EncuestaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strEncuestaScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strEncuestaScript.Substring(indexOfArrayHistory, strEncuestaScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strEncuestaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strEncuestaScript.Substring(endIndexOfMainElement + indexOfArray, strEncuestaScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (EncuestaModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in EncuestaModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Encuesta.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Encuesta.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Encuesta.js")))
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
        public ActionResult EncuestaPropertyBag()
        {
            return PartialView("EncuestaPropertyBag", "Encuesta");
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
                var whereClauseFormat = "Object = 45110 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Encuesta.Clave= " + RecordId;
                            var result = _IEncuestaApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EncuestaPropertyMapper());
			
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
                    (EncuestaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            EncuestaPropertyMapper oEncuestaPropertyMapper = new EncuestaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEncuestaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEncuestaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Encuestas == null)
                result.Encuestas = new List<Encuesta>();

            var data = result.Encuestas.Select(m => new EncuestaGridModel
            {
                Clave = m.Clave
                        ,ModuloDescripcion = CultureHelper.GetTraduction(m.Modulo_Modulo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Modulo_Modulo_Encuesta.Descripcion
                        ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(m.Tipo_Encuesta_Tipo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                        ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Clave.ToString(), "Descripcion") ?? (string)m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
			,Pregunta_1 = m.Pregunta_1
			,Pregunta_2 = m.Pregunta_2
			,Pregunta_3 = m.Pregunta_3
			,Pregunta_4 = m.Pregunta_4
			,Pregunta_5 = m.Pregunta_5

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(45110, arrayColumnsVisible), "EncuestaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(45110, arrayColumnsVisible), "EncuestaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(45110, arrayColumnsVisible), "EncuestaList_" + DateTime.Now.ToString());
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

            _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EncuestaPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (EncuestaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            EncuestaPropertyMapper oEncuestaPropertyMapper = new EncuestaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEncuestaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEncuestaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Encuestas == null)
                result.Encuestas = new List<Encuesta>();

            var data = result.Encuestas.Select(m => new EncuestaGridModel
            {
                Clave = m.Clave
                        ,ModuloDescripcion = CultureHelper.GetTraduction(m.Modulo_Modulo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Modulo_Modulo_Encuesta.Descripcion
                        ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(m.Tipo_Encuesta_Tipo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                        ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Clave.ToString(), "Descripcion") ?? (string)m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
			,Pregunta_1 = m.Pregunta_1
			,Pregunta_2 = m.Pregunta_2
			,Pregunta_3 = m.Pregunta_3
			,Pregunta_4 = m.Pregunta_4
			,Pregunta_5 = m.Pregunta_5

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
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEncuestaApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Encuesta_Datos_GeneralesModel varEncuesta)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Encuesta_Datos_GeneralesInfo = new Encuesta_Datos_Generales
                {
                    Clave = varEncuesta.Clave
                                            ,Modulo = varEncuesta.Modulo
                        ,Tipo_Encuesta = varEncuesta.Tipo_Encuesta
                        ,Numero_de_Preguntas = varEncuesta.Numero_de_Preguntas
                        ,Pregunta_1 = varEncuesta.Pregunta_1
                        ,Pregunta_2 = varEncuesta.Pregunta_2
                        ,Pregunta_3 = varEncuesta.Pregunta_3
                        ,Pregunta_4 = varEncuesta.Pregunta_4
                        ,Pregunta_5 = varEncuesta.Pregunta_5
                    
                };

                result = _IEncuestaApiConsumer.Update_Datos_Generales(Encuesta_Datos_GeneralesInfo).Resource.ToString();
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
                _IEncuestaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEncuestaApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Encuesta_Datos_GeneralesModel
                {
                    Clave = m.Clave
                        ,Modulo = m.Modulo
                        ,ModuloDescripcion = CultureHelper.GetTraduction(m.Modulo_Modulo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Modulo_Modulo_Encuesta.Descripcion
                        ,Tipo_Encuesta = m.Tipo_Encuesta
                        ,Tipo_EncuestaDescripcion = CultureHelper.GetTraduction(m.Tipo_Encuesta_Tipo_Encuesta.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_Encuesta_Tipo_Encuesta.Descripcion
                        ,Numero_de_Preguntas = m.Numero_de_Preguntas
                        ,Numero_de_PreguntasDescripcion = CultureHelper.GetTraduction(m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Clave.ToString(), "Descripcion") ?? (string)m.Numero_de_Preguntas_Catalogo_Numero_de_Preguntas.Descripcion
			,Pregunta_1 = m.Pregunta_1
			,Pregunta_2 = m.Pregunta_2
			,Pregunta_3 = m.Pregunta_3
			,Pregunta_4 = m.Pregunta_4
			,Pregunta_5 = m.Pregunta_5

                    
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

