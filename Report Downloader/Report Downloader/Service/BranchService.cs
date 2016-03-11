using System.Data;
using Report_Downloader.Data;
using Report_Downloader.Helper;
using Report_Downloader.Model;
using System.Collections.Generic;

namespace Report_Downloader.Service
{
    public class BranchService
    {
        private Container container;
        private const string getBranchQuery = "";

        #region Constructor:

        public BranchService()
        {
            this.container = new Container();
            this.container.Map<IFactory, DataContextFactory>();
        }

        #endregion

        public IList<BranchModel> GetBranches()
        {
            var context = container.GetDataContext<IFactory>();
            using (var command = context.CreateQuery())
                return command.List<BranchModel>(getBranchQuery, CommandType.Text);
        }
    }
}
