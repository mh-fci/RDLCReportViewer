using RDLCReportViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RDLCReportViewer.Controllers
{
    public class ReportController : Controller
    {
        #region Fields
        private readonly ReportViewerViewModel _model;
        #endregion

        #region Ctor
        public ReportController()
        {
            _model = new ReportViewerViewModel();
        }
        #endregion
        // GET: Report
        public ActionResult EmployeeInfo()
        {
            _model.ReportPath = Url.Content("~/Reports/viewers/EmployeeInfo.aspx");
            return View("ReportViewer", _model);
        }
    }
}