using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.VMs
{
    public class LocVM
    {
        public int LID { get; set; }
        public string? SNm { get; set; }
        public string? FNm { get; set; }
        public string? LCd { get; set; }

    }
}
