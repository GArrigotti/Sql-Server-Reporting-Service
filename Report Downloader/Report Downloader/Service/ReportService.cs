using Report_Downloader.Helper;
using Report_Downloader.Model;
using System;
using System.Collections.Generic;

namespace Report_Downloader.Service
{
    public class ReportService
    {
        public void SaveReportCard(IEnumerable<BranchModel> branches)
        {
            foreach(var branch in branches)
            {
                Console.WriteLine("Saving Report Card for {0} #{1}", branch.BranchName, branch.BranchNumber);

                var reportCardModel = new ReportCardModel();
                reportCardModel.Branch = branch.BranchNumber.ToString();

                Report.BuildReport(reportCardModel, new ReportServerModel());
            }
        }
    }
}
