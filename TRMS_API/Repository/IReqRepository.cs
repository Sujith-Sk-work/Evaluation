using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRMS_API.Models;
using TRMS_API.VewModel;

namespace TRMS_API.Repository
{
    public interface IReqRepository
    {
        //Operations
        Task<List<RequestViewModel>> GetFullReq();

        Task<List<TblRequest>> GetReq();

        Task<int> AddReq(TblRequest req);

        Task<int> UpdateReq(TblRequest req);
    }
}
