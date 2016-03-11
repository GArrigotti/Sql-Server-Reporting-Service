using System.Configuration;

namespace Report_Downloader.Model
{
    public class EmailModel
    {
        private string message;

        #region Constructor:

        public EmailModel(string message)
        {
            this.message = message;
        }

        #endregion

        #region Read Only:

        public string From
        {
            get { return ConfigurationManager.AppSettings["MailFrom"]; }
        }

        public string To
        {
            get { return ConfigurationManager.AppSettings["MailTo"]; }
        }

        public string Subject
        {
            get { return ConfigurationManager.AppSettings["MailSubject"]; }
        }

        public string Message
        {
            get { return message; }
        }

        #endregion
    }
}
