using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Category
    {
        [Key]
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Obligatory Field")]
        [StringLength(15, ErrorMessage ="{0} The field must have between {2} and {1}", MinimumLength = 4)]
        public string Name { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; }
    }
}
