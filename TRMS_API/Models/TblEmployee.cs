using System;
using System.Collections.Generic;

namespace TRMS_API.Models
{
    public partial class TblEmployee
    {
        public TblEmployee()
        {
            TblRequest = new HashSet<TblRequest>();
        }

        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public int? LId { get; set; }

        public virtual TblLogin L { get; set; }
        public virtual ICollection<TblRequest> TblRequest { get; set; }
    }
}
