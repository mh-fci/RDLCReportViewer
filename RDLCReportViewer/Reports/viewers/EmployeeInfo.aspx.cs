using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RDLCReportViewer.Controllers.MySessionTestController;

namespace RDLCReportViewer.Reports.viewers
{
    public partial class EmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                var data = Employee.GetEmployeList();
                if (data.Count() > 0)
                {
                    GenerateEmployeeInfoReport(data);
                    this.lblMsg.Text = string.Empty;
                }
                else
                {
                    rvEmployeeInfo.Reset();
                    lblMsg.Text = string.Empty;
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void rvEmployeeInfo_ReportRefresh(object sender, CancelEventArgs e)
        {
            btnViewReport_Click(null, null);
        }
        public void GenerateEmployeeInfoReport(List<Employee> data)
        {
            rvEmployeeInfo.Reset();
            rvEmployeeInfo.ProcessingMode = ProcessingMode.Local;
            rvEmployeeInfo.LocalReport.ReportPath = Server.MapPath("~/Reports/rdlc/EmployeeRpt.rdlc");


            #region Processing Report Data
            var ddd = Session["MyVar"] as Student;
            #endregion
            data.Add(new Employee() { Id = ddd.studentID, Address = ddd.studentAddress, Name = ddd.studentName });
            ReportDataSource dataSource = new ReportDataSource("DsEmployee", data);
            rvEmployeeInfo.LocalReport.DataSources.Add(dataSource);
            
            rvEmployeeInfo.DataBind();
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public static List<Employee> GetEmployeList()
            {
                var list = new List<Employee>();

                list.Add(new Employee() { Id = 1, Name = "Maruf", Address = "Mirpur" });
                list.Add(new Employee() { Id = 2, Name = "Maruf H", Address = "Mirpur 1" });
                list.Add(new Employee() { Id = 3, Name = "Maruf Hossain", Address = "Mirpur 2" });

                return list;
            }

        }
    }
}