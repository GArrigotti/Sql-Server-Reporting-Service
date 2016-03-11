using Report_Downloader.Helper;
using Report_Downloader.Service;
using System;

namespace Report_Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Started..");

            var domain = AppDomain.CurrentDomain;
            domain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);

            Console.WriteLine("Get Branch Information...");

            var branchService = new BranchService();
            var branches = branchService.GetBranches();
            
            Console.WriteLine("Found {0} Branches...", branches.Count);

            var reportService = new ReportService();
            reportService.SaveReportCard(branches);

            Console.WriteLine("Completed...");
        }

        #region Protected:

        protected static void ErrorHandler(object sender, UnhandledExceptionEventArgs argument)
        {
            var exception = (Exception)argument.ExceptionObject;
            Mailer.SendEmail(exception.Message);
        }

        #endregion
    }
}
