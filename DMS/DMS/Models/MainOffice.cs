using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class MainOffice
    {
        [Key]
        public int MoID { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string ShortName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string MoCode { get; set; }

        [ForeignKey("Location")]
        public int LoId { get; set; }



        public Location Location { get; set; }

    }
}
