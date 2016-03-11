using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report_Downloader.Model
{
    public class SmtpServerModel
    {
        public string SmtpHost
        {
            get { return ConfigurationManager.AppSettings["SmtpHost"]; }
        }

        public int SmtpPort
        {
            get { return 25; }
        }

        public string SmtpUsername
        {
            get { return ConfigurationManager.AppSettings["SmtpUsername"]; }
        }

        public string SmtpPassword
        {
            get { return ConfigurationManager.AppSettings["SmtpPassword"]; }
        }
    }
}
