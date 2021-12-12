using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDtable.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        
        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [Required]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Address { get; set; }
    }
}
