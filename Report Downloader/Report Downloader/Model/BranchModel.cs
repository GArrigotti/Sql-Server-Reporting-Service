using Report_Downloader.Helper.Attributes;

namespace Report_Downloader.Model
{
    public class BranchModel
    {
        [Column("Name")]
        public string BranchName { get; set; }

        [Column("Branch")]
        public int BranchNumber { get; set; }
    }
}
