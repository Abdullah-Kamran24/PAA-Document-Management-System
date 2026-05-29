using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class Location 
    {
        [Key]
        public int LoID { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string ShortName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string LoCode { get; set; }

    }
}
