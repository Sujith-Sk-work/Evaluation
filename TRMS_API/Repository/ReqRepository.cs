using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;
using TRMS_API.VewModel;

namespace TRMS_API.Repository
{
    public class ReqRepository : IReqRepository
    {
        //Database injection
        TRMSDBContext db;

        public ReqRepository(TRMSDBContext db)
        {
            this.db = db;
        }

        //Get Full req
        public async Task<List<RequestViewModel>> GetFullReq()
        {
            if (db != null)
            {
                return await (from req in db.TblRequest
                              from project in db.TblProject
                              from emp in db.TblEmployee
                              where req.EmpId == emp.EmpId
                              where req.ProjectId == project.ProjectId
                              select new RequestViewModel
                              {
                                  RequestId = req.RequestId,
                                  FirstName = emp.FirstName,
                                  CauseTravel = req.CauseTravel,
                                  Source = req.Source,
                                  Destination = req.Destination,
                                  FromDate = req.FromDate,
                                  ToDate = req.ToDate,
                                  NoOfDays = req.NoOfDays,
                                  Mode = req.Mode,
                                  ProjectName = project.ProjectName,
                                  Priority = req.Priority,
                                  Status = req.Status
                              }


                    ).ToListAsync();
            }
            return null;
        }

        public async Task<List<TblRequest>> GetReq()
        {
            if (db != null)
            {
                return await db.TblRequest.ToListAsync();
            }
            return null;
        }
        public async Task<int> AddReq(TblRequest req)
        {
            if (db != null)
            {
                await db.TblRequest.AddAsync(req);
                await db.SaveChangesAsync();
                return req.RequestId;
            }
            return 0;
        }



        public async Task<int> UpdateReq(TblRequest req)
        {
            if (db != null)
            {
                db.TblRequest.Update(req);
                await db.SaveChangesAsync();
                return req.RequestId;
            }
            return 0;
        }
    }
}
