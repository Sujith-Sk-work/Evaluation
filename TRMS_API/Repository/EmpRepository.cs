using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;

namespace TRMS_API.Repository
{
    public class EmpRepository : IEmpRepository
    {
        //Database Injection
        TRMSDBContext db;

        public EmpRepository(TRMSDBContext db)
        {
            this.db = db;
        }




        //Operations

        //GET ALL EMPLOYEE
        public async Task<List<TblEmployee>> GetAllEmp()
        {
            if (db != null)
            {
                return await db.TblEmployee.ToListAsync();
            }
            return null;
        }

        //GET A EMPLOYEE
        public async Task<TblEmployee> GetEmp(int id)
        {
            var emp = await db.TblEmployee.SingleOrDefaultAsync(u => u.EmpId == id);
            if (emp == null)
            {
                return null;
            }
            return emp;
        }

        //Add an employee
        public async Task<int> AddEmp(TblEmployee emp)
        {
            if (db != null)
            {
                await db.TblEmployee.AddAsync(emp);
                await db.SaveChangesAsync();
                return emp.EmpId;
            }
            return 0;
        }

        //Updating Employee
        public async Task<int> UpdateEmp(TblEmployee emp)
        {
            if (db != null)
            {
                db.TblEmployee.Update(emp);
                await db.SaveChangesAsync();

            }
            return 0;
        }

        //Deleting Employee
        public async Task<int> DeleteEmp(int empId)
        {
            if (db != null)
            {
                var itemToRemove = db.TblEmployee.SingleOrDefault(x => x.EmpId == empId); //returns a single item.

                if (itemToRemove != null)
                {
                    db.TblEmployee.Remove(itemToRemove);
                    await db.SaveChangesAsync();
                    return empId;
                }
                return 0;
            }
            return 0;
        }


        //Add Login Details
        public async Task<int> AddLogin(TblLogin login)
        {
            if (db != null)
            {
                await db.TblLogin.AddAsync(login);
                await db.SaveChangesAsync();
                return login.LId;
            }
            return 0;
        }
    }
}
