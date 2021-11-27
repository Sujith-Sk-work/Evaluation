using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;

namespace TRMS_API.Repository
{
    public interface ILoginRepository
    {
        //Methods
        //GET Methods
        Task<ActionResult<TblLogin>> GetUserByPassword(string un, string pwd);

        public TblLogin validateUser(string username, string password);
    }
}
