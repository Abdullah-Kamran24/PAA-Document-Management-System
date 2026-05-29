using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class Branch 
    {
        [Key]
        public int BrID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ShortName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string BrCode { get; set; }

        [ForeignKey("Directorate")]
        public int DrId { get; set; }
        public Directorate Directorate { get; set; }


    }
}
