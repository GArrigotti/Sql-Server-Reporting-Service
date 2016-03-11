using System;

namespace Report_Downloader.Helper.Attributes
{
    internal class ColumnAttribute : Attribute
    {
        private string column;

        #region Constructor:

        public ColumnAttribute(string column)
        {
            this.column = column;
        }

        #endregion

        public string Column
        {
            get { return column; }
        }
    }
}
