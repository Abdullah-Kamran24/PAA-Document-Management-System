using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class Directorate
    {
        [Key]
        public int DrID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ShortName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string DrCode { get; set; }

        [ForeignKey("MainOffice")]
        public int MoId { get; set; }
        public MainOffice MainOffice { get; set; }

    }
}
