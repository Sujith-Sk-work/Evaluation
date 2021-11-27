using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;

namespace TRMS_API.Repository
{
    public interface IEmpRepository
    {
        //Operations
        Task<List<TblEmployee>> GetAllEmp();

        Task<TblEmployee> GetEmp(int id);

        Task<int> AddEmp(TblEmployee emp);

        Task<int> UpdateEmp(TblEmployee emp);

        Task<int> DeleteEmp(int empId);

        Task<int> AddLogin(TblLogin login); 
    }
}
