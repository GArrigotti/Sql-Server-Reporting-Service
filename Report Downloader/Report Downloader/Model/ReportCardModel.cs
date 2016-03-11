using System;
using System.Collections.Generic;

namespace Report_Downloader.Model
{
    public class ReportCardModel
    {
        #region Read Only: 'Properties'

        public string Months
        {
            get { return DateTime.Now.Month.ToString(); }
        }

        public string Years
        {
            get { return DateTime.Now.Year.ToString(); }
        }

        public string ReportLevel
        {
            get { return "3"; }
        }

        public IEnumerable<string> Trucks
        {
            get { return new string[] { "12", "2", "3", "4", "5" }; }
        }

        public IEnumerable<string> Region
        {
            get { return new string[] { null }; }
        }

        #endregion

        public string Branch { get; set; }
    }
}
