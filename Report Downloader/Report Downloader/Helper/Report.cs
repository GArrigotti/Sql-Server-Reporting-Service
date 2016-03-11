using Microsoft.Reporting.WebForms;
using Report_Downloader.Model;
using SimpleImpersonation;
using System;
using System.IO;
using System.Linq;

namespace Report_Downloader.Helper
{
    public static class Report
    {
        public static void BuildReport<TReport>(TReport report, ReportServerModel server)
        {
            var properties = typeof(TReport).GetProperties();
            var reportParameters = new ReportParameter[properties.Count()];

            // Associate: 'Generic Model to Report Parameter'
            for (int index = 0; index < properties.Count(); index++)
            {
                dynamic value = properties[index].GetValue(report, null);
                reportParameters[index] = new ReportParameter(properties[index].Name, value);
            }

            // Build: 'Control'
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.ServerReport.ReportServerUrl = server.ReportServerUrl;
            reportViewer.ServerReport.ReportPath = server.ReportPath;
            reportViewer.ServerReport.SetParameters(reportParameters);

            var reportName = String.Format("Report-#{0}.pdf", report.GetType().GetProperty("Branch").GetValue(report, null));
            var renderedReport = reportViewer.ServerReport.Render("PDF");

            // Build: 'Output Path, with File Name'
            var uri = String.Format(@"", reportName);

            // Stream: 'Create'
            using(Impersonation.LogonUser("", "", "", LogonType.NetworkCleartext))
            using (var stream = new FileStream(uri, FileMode.Create, FileAccess.Write))
                stream.Write(renderedReport, 0, renderedReport.Length);
        }
    }
}
