using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTEPortal.Entities.Modals
{
    public class MstState
    {
        [Key]
        public Int16 StateId { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string StateNameEng { get; set; } = null!;

        [StringLength(60)]
        public string StateNameHin { get; set; } = null!;

        [Unicode(false)]
        [StringLength(2)]
        public string StateCode { get; set; } = null!;
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Unicode(false)]
        [StringLength(50)]
        public string IPAddress { get; set; }

        public int? LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}

