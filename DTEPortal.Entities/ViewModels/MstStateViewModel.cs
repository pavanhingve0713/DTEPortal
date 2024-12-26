using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Entities.ViewModels
{
    public class MstStateViewModel
    {

        public Int16 StateId { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
       
        [Display(Name = "State Name (In English)")]
        public string StateNameEng { get; set; } = null!;

        [StringLength(60)]
        [Display(Name = "राज्य का नाम (हिंदी में)")]
       
        [Required(ErrorMessage = "कृपया राज्य का नाम दर्ज करे।")]
        public string StateNameHin { get; set; } = null!;

        [StringLength(2)]
        [Unicode(false)]
        [Required(ErrorMessage = "Field is required.")]
        [MinLength(2, ErrorMessage = "Code No. must be at least 2 digit.")]
        
        [Display(Name = "State Code No.")]
        public string StateCode { get; set; } = null!;

        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string IPAddress { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}
