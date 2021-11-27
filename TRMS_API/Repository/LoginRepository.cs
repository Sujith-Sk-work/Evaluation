using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;

namespace TRMS_API.Repository
{
    public class LoginRepository:ILoginRepository
    {
        //Injecting Database
        TRMSDBContext db;

        //Constructor
        public LoginRepository(TRMSDBContext db)
        {
            this.db = db;
        }

        //GET methods
        //getting username and password 
        public async Task<ActionResult<TblLogin>> GetUserByPassword(string un, string pwd)
        {
            if (db != null)
            {
                TblLogin user = await db.TblLogin.FirstOrDefaultAsync(u => u.UserName == un && u.UserPassword == pwd);
                if (user != null)
                {
                    return user;

                }
                return null;
            }
            return null;
        }

        //Validating user
        public TblLogin validateUser(string userName, string password)
        {
            if (db != null)
            {
                TblLogin user = db.TblLogin.FirstOrDefault(u => u.UserName == userName && u.UserPassword == password);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            return null;
        }

    }
}
