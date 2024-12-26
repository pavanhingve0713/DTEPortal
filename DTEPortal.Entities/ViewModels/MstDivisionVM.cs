using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Entities.ViewModels
{
    public class MstDivisionVM
    {
        public int DivisionId { get; set; }

        [Display(Name = "State Name")]
        public string StateNameEng { get; set; }

        [Display(Name = "Division Name")]
        public string DivisionNameEng { get; set; }

        [Display(Name = "संभाग का नाम")]
        public string DivisionNameHin { get; set; }

        [Display(Name = "Code No.")]
        public string DivisionCode { get; set; }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }
    }
}
