using System;
using System.Collections.Generic;

namespace TRMS_API.Models
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int LId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
