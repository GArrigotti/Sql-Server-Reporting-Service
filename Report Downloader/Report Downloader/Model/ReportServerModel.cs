using System;

namespace Report_Downloader.Model
{
    public class ReportServerModel
    {
        public Uri ReportServerUrl
        {
            get { return new Uri("http://svr-dw/ReportServer"); }
        }

        public string ReportPath
        {
            get { return @"/Report Cards/Branch Report Card"; }
        }
    }
}
