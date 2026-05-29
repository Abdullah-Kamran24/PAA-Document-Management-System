using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.VMs
{
    public class MoVM
    {
        public int MID { get; set; }
        public string SNm { get; set; }
        public string FNm { get; set; }
        public string MCd { get; set; }
        public int LoId { get; set; }
    }
}

