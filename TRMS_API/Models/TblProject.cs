using System;
using System.Collections.Generic;

namespace TRMS_API.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblRequest = new HashSet<TblRequest>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<TblRequest> TblRequest { get; set; }
    }
}
