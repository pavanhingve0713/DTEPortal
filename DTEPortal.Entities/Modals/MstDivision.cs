using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Entities.Modals
{
    public class MstDivision
    {
        [Key]
        public int DivisionId { get; set; }
        [Required(ErrorMessage = "Select State.")]
        [DisplayName("State Name")]
        public Int16 StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual MstState? MstState { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [Unicode(false)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only")]
        [DisplayName("Division Name (In English)")]
        [StringLength(50)]
        public string DivisionNameEng { get; set; }

        [Required(ErrorMessage = "कृपया संभाग का नाम दर्ज करें।")]
        [RegularExpression(@"^[\x41-\x5A\x30-\x39\x61-\x7A\x2C-\x2E\u0900-\u097F\s]*$", ErrorMessage = "Use alphanumeric, hindi  & some special symbols like (-)Hyphen, (,)Comma, (.)Dot characters only.")]
        [DisplayName("संभाग का नाम (हिंदी में)")]
        [StringLength(60)]
        public string? DivisionNameHin { get; set; }

        [Required(ErrorMessage = "Field is required.")]
        [MaxLength(2)]
        [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Must be 2 digits numbers")]
        [Display(Name = "Division Code No.")]
        [StringLength(2)]
        [Unicode(false)]
        public string DivisionCode { get; set; }

        [DisplayName("IsActive")]
        public bool IsActive { get; set; }

    }
}
