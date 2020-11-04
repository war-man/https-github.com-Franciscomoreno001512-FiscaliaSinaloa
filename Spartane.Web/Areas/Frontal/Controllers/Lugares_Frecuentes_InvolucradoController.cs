﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Lugares_Frecuentes_Involucrado;
using Spartane.Core.Domain.Lugares;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Lugares_Frecuentes_Involucrado;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Lugares_Frecuentes_Involucrado;
using Spartane.Web.Areas.WebApiConsumer.Lugares;

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
    public class Lugares_Frecuentes_InvolucradoController : Controller
    {
        #region "variable declaration"

        private ILugares_Frecuentes_InvolucradoService service = null;
        private ILugares_Frecuentes_InvolucradoApiConsumer _ILugares_Frecuentes_InvolucradoApiConsumer;
        private ILugaresApiConsumer _ILugaresApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Lugares_Frecuentes_InvolucradoController(ILugares_Frecuentes_InvolucradoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ILugares_Frecuentes_InvolucradoApiConsumer Lugares_Frecuentes_InvolucradoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ILugaresApiConsumer LugaresApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ILugares_Frecuentes_InvolucradoApiConsumer = Lugares_Frecuentes_InvolucradoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ILugaresApiConsumer = LugaresApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Lugares_Frecuentes_Involucrado
        [ObjectAuth(ObjectId = (ModuleObjectId)45311, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45311);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Lugares_Frecuentes_Involucrado/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)45311, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45311);
            ViewBag.Permission = permission;
            var varLugares_Frecuentes_Involucrado = new Lugares_Frecuentes_InvolucradoModel();
			
            ViewBag.ObjectId = "45311";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Lugares_Frecuentes_InvolucradoData = _ILugares_Frecuentes_InvolucradoApiConsumer.GetByKeyComplete(Id).Resource.Lugares_Frecuentes_Involucrados[0];
                if (Lugares_Frecuentes_InvolucradoData == null)
                    return HttpNotFound();

                varLugares_Frecuentes_Involucrado = new Lugares_Frecuentes_InvolucradoModel
                {
                    Clave = (int)Lugares_Frecuentes_InvolucradoData.Clave
                    ,Tipo_de_Lugar = Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar
                    ,Tipo_de_LugarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar), "Lugares") ??  (string)Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar_Lugares.Descripcion
                    ,Descripcion = Lugares_Frecuentes_InvolucradoData.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ILugaresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Lugaress_Tipo_de_Lugar = _ILugaresApiConsumer.SelAll(true);
            if (Lugaress_Tipo_de_Lugar != null && Lugaress_Tipo_de_Lugar.Resource != null)
                ViewBag.Lugaress_Tipo_de_Lugar = Lugaress_Tipo_de_Lugar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Lugares", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varLugares_Frecuentes_Involucrado);
        }
		
	[HttpGet]
        public ActionResult AddLugares_Frecuentes_Involucrado(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45311);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Lugares_Frecuentes_InvolucradoModel varLugares_Frecuentes_Involucrado= new Lugares_Frecuentes_InvolucradoModel();


            if (id.ToString() != "0")
            {
                var Lugares_Frecuentes_InvolucradosData = _ILugares_Frecuentes_InvolucradoApiConsumer.ListaSelAll(0, 1000, "Lugares_Frecuentes_Involucrado.Clave=" + id, "").Resource.Lugares_Frecuentes_Involucrados;
				
				if (Lugares_Frecuentes_InvolucradosData != null && Lugares_Frecuentes_InvolucradosData.Count > 0)
                {
					var Lugares_Frecuentes_InvolucradoData = Lugares_Frecuentes_InvolucradosData.First();
					varLugares_Frecuentes_Involucrado= new Lugares_Frecuentes_InvolucradoModel
					{
						Clave  = Lugares_Frecuentes_InvolucradoData.Clave 
	                    ,Tipo_de_Lugar = Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar
                    ,Tipo_de_LugarDescripcion = CultureHelper.GetTraduction(Convert.ToString(Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar), "Lugares") ??  (string)Lugares_Frecuentes_InvolucradoData.Tipo_de_Lugar_Lugares.Descripcion
                    ,Descripcion = Lugares_Frecuentes_InvolucradoData.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ILugaresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Lugaress_Tipo_de_Lugar = _ILugaresApiConsumer.SelAll(true);
            if (Lugaress_Tipo_de_Lugar != null && Lugaress_Tipo_de_Lugar.Resource != null)
                ViewBag.Lugaress_Tipo_de_Lugar = Lugaress_Tipo_de_Lugar.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Lugares", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddLugares_Frecuentes_Involucrado", varLugares_Frecuentes_Involucrado);
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
        public ActionResult GetLugaresAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ILugaresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ILugaresApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Lugares", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Lugares_Frecuentes_InvolucradoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ILugares_Frecuentes_InvolucradoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Lugares_Frecuentes_Involucrados == null)
                result.Lugares_Frecuentes_Involucrados = new List<Lugares_Frecuentes_Involucrado>();

            return Json(new
            {
                data = result.Lugares_Frecuentes_Involucrados.Select(m => new Lugares_Frecuentes_InvolucradoGridModel
                    {
                    Clave = m.Clave
                        ,Tipo_de_LugarDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Lugar_Lugares.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Lugar_Lugares.Descripcion
			,Descripcion = m.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
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
                _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Lugares_Frecuentes_Involucrado varLugares_Frecuentes_Involucrado = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ILugares_Frecuentes_InvolucradoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Lugares_Frecuentes_InvolucradoModel varLugares_Frecuentes_Involucrado)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Lugares_Frecuentes_InvolucradoInfo = new Lugares_Frecuentes_Involucrado
                    {
                        Clave = varLugares_Frecuentes_Involucrado.Clave
                        ,Tipo_de_Lugar = varLugares_Frecuentes_Involucrado.Tipo_de_Lugar
                        ,Descripcion = varLugares_Frecuentes_Involucrado.Descripcion

                    };

                    result = !IsNew ?
                        _ILugares_Frecuentes_InvolucradoApiConsumer.Update(Lugares_Frecuentes_InvolucradoInfo, null, null).Resource.ToString() :
                         _ILugares_Frecuentes_InvolucradoApiConsumer.Insert(Lugares_Frecuentes_InvolucradoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Lugares_Frecuentes_Involucrado script
        /// </summary>
        /// <param name="oLugares_Frecuentes_InvolucradoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Lugares_Frecuentes_InvolucradoModuleAttributeList)
        {
            for (int i = 0; i < Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strLugares_Frecuentes_InvolucradoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Lugares_Frecuentes_Involucrado.js")))
            {
                strLugares_Frecuentes_InvolucradoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Lugares_Frecuentes_Involucrado element attributes
            string userChangeJson = jsSerialize.Serialize(Lugares_Frecuentes_InvolucradoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strLugares_Frecuentes_InvolucradoScript.IndexOf("inpuElementArray");
            string splittedString = strLugares_Frecuentes_InvolucradoScript.Substring(indexOfArray, strLugares_Frecuentes_InvolucradoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strLugares_Frecuentes_InvolucradoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strLugares_Frecuentes_InvolucradoScript.Substring(indexOfArrayHistory, strLugares_Frecuentes_InvolucradoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strLugares_Frecuentes_InvolucradoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strLugares_Frecuentes_InvolucradoScript.Substring(endIndexOfMainElement + indexOfArray, strLugares_Frecuentes_InvolucradoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Lugares_Frecuentes_InvolucradoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strLugares_Frecuentes_InvolucradoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strLugares_Frecuentes_InvolucradoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strLugares_Frecuentes_InvolucradoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strLugares_Frecuentes_InvolucradoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Lugares_Frecuentes_Involucrado.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Lugares_Frecuentes_Involucrado.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Lugares_Frecuentes_Involucrado.js")))
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
        public ActionResult Lugares_Frecuentes_InvolucradoPropertyBag()
        {
            return PartialView("Lugares_Frecuentes_InvolucradoPropertyBag", "Lugares_Frecuentes_Involucrado");
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

            _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Lugares_Frecuentes_InvolucradoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ILugares_Frecuentes_InvolucradoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Lugares_Frecuentes_Involucrados == null)
                result.Lugares_Frecuentes_Involucrados = new List<Lugares_Frecuentes_Involucrado>();

            var data = result.Lugares_Frecuentes_Involucrados.Select(m => new Lugares_Frecuentes_InvolucradoGridModel
            {
                Clave = m.Clave
                ,Tipo_de_LugarDescripcion = (string)m.Tipo_de_Lugar_Lugares.Descripcion
                ,Descripcion = m.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Lugares_Frecuentes_InvolucradoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Lugares_Frecuentes_InvolucradoList_" + DateTime.Now.ToString());
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

            _ILugares_Frecuentes_InvolucradoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Lugares_Frecuentes_InvolucradoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ILugares_Frecuentes_InvolucradoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Lugares_Frecuentes_Involucrados == null)
                result.Lugares_Frecuentes_Involucrados = new List<Lugares_Frecuentes_Involucrado>();

            var data = result.Lugares_Frecuentes_Involucrados.Select(m => new Lugares_Frecuentes_InvolucradoGridModel
            {
                Clave = m.Clave
                ,Tipo_de_LugarDescripcion = (string)m.Tipo_de_Lugar_Lugares.Descripcion
                ,Descripcion = m.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
