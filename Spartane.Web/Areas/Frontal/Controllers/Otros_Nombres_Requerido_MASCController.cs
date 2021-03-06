﻿using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Otros_Nombres_Requerido_MASC;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Otros_Nombres_Requerido_MASC;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Otros_Nombres_Requerido_MASC;

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
    public class Otros_Nombres_Requerido_MASCController : Controller
    {
        #region "variable declaration"

        private IOtros_Nombres_Requerido_MASCService service = null;
        private IOtros_Nombres_Requerido_MASCApiConsumer _IOtros_Nombres_Requerido_MASCApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Otros_Nombres_Requerido_MASCController(IOtros_Nombres_Requerido_MASCService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IOtros_Nombres_Requerido_MASCApiConsumer Otros_Nombres_Requerido_MASCApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IOtros_Nombres_Requerido_MASCApiConsumer = Otros_Nombres_Requerido_MASCApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Otros_Nombres_Requerido_MASC
        [ObjectAuth(ObjectId = (ModuleObjectId)45343, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45343);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Otros_Nombres_Requerido_MASC/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)45343, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45343);
            ViewBag.Permission = permission;
            var varOtros_Nombres_Requerido_MASC = new Otros_Nombres_Requerido_MASCModel();
			
            ViewBag.ObjectId = "45343";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Otros_Nombres_Requerido_MASCData = _IOtros_Nombres_Requerido_MASCApiConsumer.GetByKeyComplete(Id).Resource.Otros_Nombres_Requerido_MASCs[0];
                if (Otros_Nombres_Requerido_MASCData == null)
                    return HttpNotFound();

                varOtros_Nombres_Requerido_MASC = new Otros_Nombres_Requerido_MASCModel
                {
                    Clave = (int)Otros_Nombres_Requerido_MASCData.Clave
                    ,Descripcion = Otros_Nombres_Requerido_MASCData.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varOtros_Nombres_Requerido_MASC);
        }
		
	[HttpGet]
        public ActionResult AddOtros_Nombres_Requerido_MASC(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 45343);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);
			Otros_Nombres_Requerido_MASCModel varOtros_Nombres_Requerido_MASC= new Otros_Nombres_Requerido_MASCModel();


            if (id.ToString() != "0")
            {
                var Otros_Nombres_Requerido_MASCsData = _IOtros_Nombres_Requerido_MASCApiConsumer.ListaSelAll(0, 1000, "Otros_Nombres_Requerido_MASC.Clave=" + id, "").Resource.Otros_Nombres_Requerido_MASCs;
				
				if (Otros_Nombres_Requerido_MASCsData != null && Otros_Nombres_Requerido_MASCsData.Count > 0)
                {
					var Otros_Nombres_Requerido_MASCData = Otros_Nombres_Requerido_MASCsData.First();
					varOtros_Nombres_Requerido_MASC= new Otros_Nombres_Requerido_MASCModel
					{
						Clave  = Otros_Nombres_Requerido_MASCData.Clave 
	                    ,Descripcion = Otros_Nombres_Requerido_MASCData.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddOtros_Nombres_Requerido_MASC", varOtros_Nombres_Requerido_MASC);
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




        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Nombres_Requerido_MASCPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IOtros_Nombres_Requerido_MASCApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Nombres_Requerido_MASCs == null)
                result.Otros_Nombres_Requerido_MASCs = new List<Otros_Nombres_Requerido_MASC>();

            return Json(new
            {
                data = result.Otros_Nombres_Requerido_MASCs.Select(m => new Otros_Nombres_Requerido_MASCGridModel
                    {
                    Clave = m.Clave
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
                _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);

                Otros_Nombres_Requerido_MASC varOtros_Nombres_Requerido_MASC = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IOtros_Nombres_Requerido_MASCApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Otros_Nombres_Requerido_MASCModel varOtros_Nombres_Requerido_MASC)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Otros_Nombres_Requerido_MASCInfo = new Otros_Nombres_Requerido_MASC
                    {
                        Clave = varOtros_Nombres_Requerido_MASC.Clave
                        ,Descripcion = varOtros_Nombres_Requerido_MASC.Descripcion

                    };

                    result = !IsNew ?
                        _IOtros_Nombres_Requerido_MASCApiConsumer.Update(Otros_Nombres_Requerido_MASCInfo, null, null).Resource.ToString() :
                         _IOtros_Nombres_Requerido_MASCApiConsumer.Insert(Otros_Nombres_Requerido_MASCInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Otros_Nombres_Requerido_MASC script
        /// </summary>
        /// <param name="oOtros_Nombres_Requerido_MASCElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Otros_Nombres_Requerido_MASCModuleAttributeList)
        {
            for (int i = 0; i < Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strOtros_Nombres_Requerido_MASCScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Otros_Nombres_Requerido_MASC.js")))
            {
                strOtros_Nombres_Requerido_MASCScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Otros_Nombres_Requerido_MASC element attributes
            string userChangeJson = jsSerialize.Serialize(Otros_Nombres_Requerido_MASCModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strOtros_Nombres_Requerido_MASCScript.IndexOf("inpuElementArray");
            string splittedString = strOtros_Nombres_Requerido_MASCScript.Substring(indexOfArray, strOtros_Nombres_Requerido_MASCScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strOtros_Nombres_Requerido_MASCScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strOtros_Nombres_Requerido_MASCScript.Substring(indexOfArrayHistory, strOtros_Nombres_Requerido_MASCScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strOtros_Nombres_Requerido_MASCScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strOtros_Nombres_Requerido_MASCScript.Substring(endIndexOfMainElement + indexOfArray, strOtros_Nombres_Requerido_MASCScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Otros_Nombres_Requerido_MASCModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strOtros_Nombres_Requerido_MASCScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strOtros_Nombres_Requerido_MASCScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strOtros_Nombres_Requerido_MASCScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strOtros_Nombres_Requerido_MASCScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Otros_Nombres_Requerido_MASC.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Otros_Nombres_Requerido_MASC.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Otros_Nombres_Requerido_MASC.js")))
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
        public ActionResult Otros_Nombres_Requerido_MASCPropertyBag()
        {
            return PartialView("Otros_Nombres_Requerido_MASCPropertyBag", "Otros_Nombres_Requerido_MASC");
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

            _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Nombres_Requerido_MASCPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IOtros_Nombres_Requerido_MASCApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Nombres_Requerido_MASCs == null)
                result.Otros_Nombres_Requerido_MASCs = new List<Otros_Nombres_Requerido_MASC>();

            var data = result.Otros_Nombres_Requerido_MASCs.Select(m => new Otros_Nombres_Requerido_MASCGridModel
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Otros_Nombres_Requerido_MASCList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Otros_Nombres_Requerido_MASCList_" + DateTime.Now.ToString());
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

            _IOtros_Nombres_Requerido_MASCApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Otros_Nombres_Requerido_MASCPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IOtros_Nombres_Requerido_MASCApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Otros_Nombres_Requerido_MASCs == null)
                result.Otros_Nombres_Requerido_MASCs = new List<Otros_Nombres_Requerido_MASC>();

            var data = result.Otros_Nombres_Requerido_MASCs.Select(m => new Otros_Nombres_Requerido_MASCGridModel
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
